/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0
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
///     A code fix provider that replaces bracketed <c>string.Join</c> formatting with <c>Fsq</c>.
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
        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        var semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
        var diagnosticNode = root?.FindNode(diagnostic.Location.SourceSpan);

        if (diagnosticNode is not InterpolatedStringExpressionSyntax expression ||
            semanticModel is null ||
            !FormatSequencePattern.TryGetArguments(
                expression, semanticModel, context.CancellationToken, out var sequence, out var separator))
            return;

        context.RegisterCodeFix(
            CodeAction.Create(
                title: Resources.HN0002CodeFixTitle,
                createChangedDocument: c => UseShorthandAsync(
                    context.Document, expression, sequence, separator, semanticModel, c),
                equivalenceKey: nameof(Resources.HN0002CodeFixTitle)),
            diagnostic);
    }

    private static async Task<Document> UseShorthandAsync(
        Document document,
        InterpolatedStringExpressionSyntax expression,
        ExpressionSyntax sequence,
        ExpressionSyntax separator,
        SemanticModel semanticModel,
        CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
            return document;

        var arguments = new List<ArgumentSyntax>
        {
            SyntaxFactory.Argument(WithoutFormattingTrivia(sequence))
        };

        if (semanticModel.GetConstantValue(separator, cancellationToken) is
            not { HasValue: true, Value: ", " } ||
            HasSignificantTrivia(separator))
            arguments.Add(SyntaxFactory.Argument(WithoutFormattingTrivia(separator)));

        var replacement = SyntaxFactory.InvocationExpression(
                SyntaxFactory.ParseExpression("global::Hussy.Net.Hussy.Fsq"),
                SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments)))
            .WithTriviaFrom(expression);

        return document.WithSyntaxRoot(root.ReplaceNode(expression, replacement));
    }

    private static ExpressionSyntax WithoutFormattingTrivia(ExpressionSyntax expression) =>
        expression
            .WithLeadingTrivia(SyntaxFactory.TriviaList(expression.GetLeadingTrivia().Where(IsSignificantTrivia)))
            .WithTrailingTrivia(SyntaxFactory.TriviaList(expression.GetTrailingTrivia().Where(IsSignificantTrivia)));

    private static bool HasSignificantTrivia(ExpressionSyntax expression) =>
        expression.GetLeadingTrivia().Any(IsSignificantTrivia) ||
        expression.GetTrailingTrivia().Any(IsSignificantTrivia) ||
        expression.DescendantTrivia(descendIntoTrivia: true).Any(IsSignificantTrivia);

    private static bool IsSignificantTrivia(SyntaxTrivia trivia) =>
        !trivia.IsKind(SyntaxKind.WhitespaceTrivia) &&
        !trivia.IsKind(SyntaxKind.EndOfLineTrivia);
}
