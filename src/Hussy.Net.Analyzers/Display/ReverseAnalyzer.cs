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

using System.Collections.Immutable;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Hussy.Net.Analyzers.Display;

/// <summary>
///     An analyzer that reports manual reversal expressions and
///     suggests using the <c>Rev</c> shorthand method instead.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class ReverseAnalyzer : DiagnosticAnalyzer
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
        context.RegisterSyntaxNodeAction(AnalyzeObjectCreation, SyntaxKind.ObjectCreationExpression);
    }

    private static void AnalyzeObjectCreation(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not ObjectCreationExpressionSyntax objectCreation ||
            objectCreation.ArgumentList?.Arguments.Count != 1)
            return;

        if (context.ContainingSymbol is IMethodSymbol
            {
                Name: "Rev",
                ContainingType.Name: "Hussy",
                ContainingNamespace: { }
            } containingMethod &&
            containingMethod.ContainingNamespace.ToDisplayString() == "Hussy.Net")
            return;

        var constructorSymbol = context.SemanticModel.GetSymbolInfo(objectCreation, context.CancellationToken).Symbol
            as IMethodSymbol;

        if (constructorSymbol?.ContainingType.SpecialType != SpecialType.System_String ||
            constructorSymbol.Parameters.Length != 1 ||
            constructorSymbol.Parameters[0].Type is not IArrayTypeSymbol { ElementType.SpecialType: SpecialType.System_Char })
            return;

        if (!TryGetReverseInputExpression(objectCreation, context.SemanticModel, context.CancellationToken, out _))
            return;

        var diagnostic = Diagnostic.Create(Rule, objectCreation.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }

    internal static bool TryGetReverseInputExpression(
        ObjectCreationExpressionSyntax objectCreation,
        SemanticModel semanticModel,
        CancellationToken cancellationToken,
        out ExpressionSyntax inputExpression)
    {
        inputExpression = null!;

        var argumentExpression = objectCreation.ArgumentList?.Arguments[0].Expression;
        if (argumentExpression is null ||
            !TryGetParameterlessInvocationReceiver(argumentExpression, "ToArray", out var reverseExpression) ||
            !TryGetParameterlessInvocationReceiver(reverseExpression, "Reverse", out var candidateInput))
            return false;

        if (TryUnwrapInputExpression(candidateInput, semanticModel, cancellationToken, out inputExpression))
            return true;

        return false;
    }

    private static bool TryGetParameterlessInvocationReceiver(
        ExpressionSyntax expression,
        string methodName,
        out ExpressionSyntax receiver)
    {
        receiver = null!;

        if (expression is not InvocationExpressionSyntax
            {
                ArgumentList.Arguments.Count: 0,
                Expression: MemberAccessExpressionSyntax memberAccess
            } ||
            memberAccess.Name.Identifier.ValueText != methodName)
            return false;

        receiver = memberAccess.Expression;
        return true;
    }

    private static bool TryUnwrapInputExpression(
        ExpressionSyntax expression,
        SemanticModel semanticModel,
        CancellationToken cancellationToken,
        out ExpressionSyntax inputExpression)
    {
        inputExpression = null!;

        if (expression is InvocationExpressionSyntax
            {
                ArgumentList.Arguments.Count: 0,
                Expression: MemberAccessExpressionSyntax memberAccess
            } invocation)
        {
            var methodSymbol = semanticModel.GetSymbolInfo(invocation, cancellationToken).Symbol as IMethodSymbol;
            var resolvedMethod = methodSymbol?.ReducedFrom ?? methodSymbol;

            if (resolvedMethod is not null)
            {
                if (resolvedMethod.Name == nameof(ToString) &&
                    !resolvedMethod.IsStatic &&
                    resolvedMethod.Parameters.Length == 0)
                {
                    inputExpression = memberAccess.Expression;
                    return true;
                }

                if (resolvedMethod.Name == "Ts" &&
                    resolvedMethod.IsExtensionMethod &&
                    resolvedMethod.Parameters.Length == 1 &&
                    resolvedMethod.ReturnType.SpecialType == SpecialType.System_String)
                {
                    inputExpression = memberAccess.Expression;
                    return true;
                }
            }
        }

        if (semanticModel.GetTypeInfo(expression, cancellationToken).Type?.SpecialType != SpecialType.System_String)
            return false;

        inputExpression = expression;
        return true;
    }
}
