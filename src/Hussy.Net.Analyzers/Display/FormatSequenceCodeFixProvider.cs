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
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Hussy.Net.Analyzers.Display;

/// <summary>
///     A code fix provider that replaces manual sequence formatting with the
///     <c>Fsq</c> shorthand method.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(FormatSequenceCodeFixProvider)), Shared]
public class FormatSequenceCodeFixProvider : CodeFixProvider
{
    /// <inheritdoc />
    public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(FormatSequenceAnalyzer.DiagnosticId);

    /// <inheritdoc />
    public override FixAllProvider? GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc />
    public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.Single();
        var diagnosticSpan = diagnostic.Location.SourceSpan;

        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        var diagnosticNode = root?.FindNode(diagnosticSpan);

        if (diagnosticNode is not ExpressionSyntax expression ||
            !FormatSequenceAnalyzer.TryGetWrappedJoinInvocation(expression, out _))
            return;

        context.RegisterCodeFix(
            CodeAction.Create(
                title: Resources.HN0002CodeFixTitle,
                createChangedDocument: c => UseShorthandAsync(context.Document, expression, c),
                equivalenceKey: nameof(Resources.HN0002CodeFixTitle)),
            diagnostic);
    }

    private static async Task<Document> UseShorthandAsync(
        Document document,
        ExpressionSyntax expression,
        CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null ||
            !FormatSequenceAnalyzer.TryGetWrappedJoinInvocation(expression, out var invocation) ||
            !FormatSequenceAnalyzer.TryGetSequenceFormattingParts(invocation, out var sequence, out var separator))
            return document;

        var newExpression = CreateFormatSequenceInvocation(sequence, separator)
            .WithTriviaFrom(expression);
        var newRoot = root.ReplaceNode(expression, newExpression);

        return document.WithSyntaxRoot(newRoot);
    }

    private static InvocationExpressionSyntax CreateFormatSequenceInvocation(
        ExpressionSyntax sequence,
        ExpressionSyntax? separator)
    {
        var arguments = new List<ArgumentSyntax>
        {
            SyntaxFactory.Argument(sequence.WithoutTrivia())
        };

        if (separator is not null && !IsDefaultSeparator(separator))
            arguments.Add(SyntaxFactory.Argument(separator.WithoutTrivia()));

        var memberAccess = SyntaxFactory.MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            SyntaxFactory.IdentifierName("Hussy"),
            SyntaxFactory.IdentifierName("Fsq"));

        return SyntaxFactory.InvocationExpression(
            memberAccess,
            SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments)));
    }

    private static bool IsDefaultSeparator(ExpressionSyntax separator) =>
        FormatSequenceAnalyzer.Unwrap(separator) is LiteralExpressionSyntax
        {
            Token.ValueText: ", "
        };
}
