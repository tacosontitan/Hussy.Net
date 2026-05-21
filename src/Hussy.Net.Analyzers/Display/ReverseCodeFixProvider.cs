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
///     A code fix provider that replaces manual reversal expressions with
///     the <c>Rev</c> shorthand method.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ReverseCodeFixProvider)), Shared]
public class ReverseCodeFixProvider : CodeFixProvider
{
    /// <inheritdoc />
    public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(ReverseAnalyzer.DiagnosticId);

    /// <inheritdoc />
    public override FixAllProvider? GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc />
    public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.Single();
        var diagnosticSpan = diagnostic.Location.SourceSpan;

        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        var diagnosticNode = root?.FindNode(diagnosticSpan);

        if (diagnosticNode is not ObjectCreationExpressionSyntax objectCreation)
            return;

        context.RegisterCodeFix(
            CodeAction.Create(
                title: Resources.HN0002CodeFixTitle,
                createChangedDocument: c => UseShorthandAsync(context.Document, objectCreation, c),
                equivalenceKey: nameof(Resources.HN0002CodeFixTitle)),
            diagnostic);
    }

    private static async Task<Document> UseShorthandAsync(
        Document document,
        ObjectCreationExpressionSyntax objectCreation,
        CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);

        if (root is null || semanticModel is null ||
            !ReverseAnalyzer.TryGetReverseInputExpression(objectCreation, semanticModel, cancellationToken, out var inputExpression))
            return document;

        var newInvocation = SyntaxFactory.InvocationExpression(
                SyntaxFactory.IdentifierName("Rev"),
                SyntaxFactory.ArgumentList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Argument(inputExpression.WithoutTrivia()))))
            .WithTriviaFrom(objectCreation);

        var newRoot = root.ReplaceNode(objectCreation, newInvocation);
        return document.WithSyntaxRoot(newRoot);
    }
}
