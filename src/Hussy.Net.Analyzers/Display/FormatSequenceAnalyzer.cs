/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Hussy.Net.Analyzers.Display;

/// <summary>
///     An analyzer that reports manually formatted sequence display strings and
///     suggests using the <c>Fsq</c> shorthand method instead.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class FormatSequenceAnalyzer : DiagnosticAnalyzer
{
    /// <summary>
    ///     The diagnostic ID for this analyzer.
    /// </summary>
    public const string DiagnosticId = "HN0002";

    private static readonly LocalizableString Title = new LocalizableResourceString(
        nameof(Resources.HN0002Title), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString MessageFormat = new LocalizableResourceString(
        nameof(Resources.HN0002MessageFormat), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString Description = new LocalizableResourceString(
        nameof(Resources.HN0002Description), Resources.ResourceManager, typeof(Resources));

    private const string Category = "Style";

    /// <summary>
    ///     The diagnostic rule for this analyzer.
    /// </summary>
    public static readonly DiagnosticDescriptor Rule = new(
        DiagnosticId, Title, MessageFormat, Category,
        DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

    /// <inheritdoc />
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(Rule);

    /// <inheritdoc />
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterSyntaxNodeAction(AnalyzeInterpolatedString, SyntaxKind.InterpolatedStringExpression);
        context.RegisterSyntaxNodeAction(AnalyzeAddExpression, SyntaxKind.AddExpression);
    }

    private static void AnalyzeInterpolatedString(SyntaxNodeAnalysisContext context)
    {
        if (context.ContainingSymbol is IMethodSymbol { Name: "Fsq" })
            return;

        if (context.Node is not InterpolatedStringExpressionSyntax interpolatedString)
            return;

        if (!TryGetWrappedJoinInvocation(interpolatedString, out _))
            return;

        var diagnostic = Diagnostic.Create(Rule, interpolatedString.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }

    private static void AnalyzeAddExpression(SyntaxNodeAnalysisContext context)
    {
        if (context.ContainingSymbol is IMethodSymbol { Name: "Fsq" })
            return;

        if (context.Node is not BinaryExpressionSyntax binaryExpression)
            return;

        if (binaryExpression.Parent is BinaryExpressionSyntax { RawKind: (int)SyntaxKind.AddExpression })
            return;

        if (!TryGetWrappedJoinInvocation(binaryExpression, out _))
            return;

        var diagnostic = Diagnostic.Create(Rule, binaryExpression.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }

    internal static bool TryGetWrappedJoinInvocation(
        ExpressionSyntax expression,
        out InvocationExpressionSyntax invocation)
    {
        expression = Unwrap(expression);

        if (expression is InterpolatedStringExpressionSyntax interpolatedString)
            return TryGetWrappedJoinInvocation(interpolatedString, out invocation);

        if (expression is BinaryExpressionSyntax binaryExpression)
            return TryGetWrappedJoinInvocation(binaryExpression, out invocation);

        invocation = null!;
        return false;
    }

    internal static bool TryGetSequenceFormattingParts(
        InvocationExpressionSyntax invocation,
        out ExpressionSyntax sequence,
        out ExpressionSyntax? separator)
    {
        sequence = null!;
        separator = null;

        invocation = (InvocationExpressionSyntax)Unwrap(invocation);

        if (invocation.Expression is not MemberAccessExpressionSyntax memberAccess)
            return false;

        var isStringType = memberAccess.Expression is
            PredefinedTypeSyntax { Keyword.RawKind: (int)SyntaxKind.StringKeyword } or
            IdentifierNameSyntax { Identifier.Text: "String" };

        if (isStringType &&
            memberAccess.Name.Identifier.Text == "Join" &&
            invocation.ArgumentList.Arguments.Count == 2)
        {
            separator = invocation.ArgumentList.Arguments[0].Expression;
            sequence = invocation.ArgumentList.Arguments[1].Expression;
            return true;
        }

        if (memberAccess.Name.Identifier.Text == "Js" &&
            invocation.ArgumentList.Arguments.Count <= 1)
        {
            sequence = memberAccess.Expression;
            separator = invocation.ArgumentList.Arguments.Count == 0
                ? null
                : invocation.ArgumentList.Arguments[0].Expression;
            return true;
        }

        return false;
    }

    private static bool TryGetWrappedJoinInvocation(
        InterpolatedStringExpressionSyntax interpolatedString,
        out InvocationExpressionSyntax invocation)
    {
        invocation = null!;

        if (interpolatedString.Contents.Count != 3)
            return false;

        if (interpolatedString.Contents[0] is not InterpolatedStringTextSyntax
            {
                TextToken.ValueText: "["
            })
            return false;

        if (interpolatedString.Contents[1] is not InterpolationSyntax
            {
                Expression: InvocationExpressionSyntax candidateInvocation
            })
            return false;

        if (interpolatedString.Contents[2] is not InterpolatedStringTextSyntax
            {
                TextToken.ValueText: "]"
            })
            return false;

        if (!TryGetSequenceFormattingParts(candidateInvocation, out _, out _))
            return false;

        invocation = candidateInvocation;
        return true;
    }

    private static bool TryGetWrappedJoinInvocation(
        BinaryExpressionSyntax binaryExpression,
        out InvocationExpressionSyntax invocation)
    {
        invocation = null!;

        var parts = new List<ExpressionSyntax>();
        CollectConcatenationParts(binaryExpression, parts);
        if (parts.Count != 3)
            return false;

        if (!IsStringLiteral(parts[0], "[") ||
            !IsStringLiteral(parts[2], "]") ||
            Unwrap(parts[1]) is not InvocationExpressionSyntax candidateInvocation ||
            !TryGetSequenceFormattingParts(candidateInvocation, out _, out _))
            return false;

        invocation = candidateInvocation;
        return true;
    }

    private static void CollectConcatenationParts(ExpressionSyntax expression, ICollection<ExpressionSyntax> parts)
    {
        expression = Unwrap(expression);

        if (expression is BinaryExpressionSyntax { RawKind: (int)SyntaxKind.AddExpression } binaryExpression)
        {
            CollectConcatenationParts(binaryExpression.Left, parts);
            CollectConcatenationParts(binaryExpression.Right, parts);
            return;
        }

        parts.Add(expression);
    }

    private static bool IsStringLiteral(ExpressionSyntax expression, string value) =>
        Unwrap(expression) is LiteralExpressionSyntax { Token.ValueText: var literalValue } &&
        literalValue == value;

    internal static ExpressionSyntax Unwrap(ExpressionSyntax expression)
    {
        while (expression is ParenthesizedExpressionSyntax parenthesizedExpression)
            expression = parenthesizedExpression.Expression;

        return expression;
    }
}
