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

namespace Hussy.Net.Analyzers.Generators;

[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(RangeCodeFixProvider)), Shared]
public class RangeCodeFixProvider : CodeFixProvider
{
    public sealed override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(RangeAnalyzer.DiagnosticId);

    public override FixAllProvider? GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var diagnostic = context.Diagnostics.Single();
        var diagnosticSpan = diagnostic.Location.SourceSpan;

        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        var diagnosticNode = root?.FindNode(diagnosticSpan);

        if (diagnosticNode is not InvocationExpressionSyntax invocation)
            return;

        context.RegisterCodeFix(
            CodeAction.Create(
                title: Resources.HN0002CodeFixTitle,
                createChangedDocument: c => UseShorthandAsync(context.Document, invocation, c),
                equivalenceKey: nameof(Resources.HN0002CodeFixTitle)),
            diagnostic);
    }

    private static async Task<Document> UseShorthandAsync(
        Document document,
        InvocationExpressionSyntax invocation,
        CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || semanticModel is null)
            return document;

        var arguments = invocation.ArgumentList.Arguments;
        if (arguments.Count != 2)
            return document;

        var startValue = semanticModel.GetConstantValue(arguments[0].Expression, cancellationToken);
        var replacementArguments = startValue.HasValue && startValue.Value is int value && value == 1
            ? SyntaxFactory.SingletonSeparatedList(arguments[1])
            : arguments;

        var newInvocation = invocation
            .WithExpression(SyntaxFactory.IdentifierName("Gr").WithTriviaFrom(invocation.Expression))
            .WithArgumentList(invocation.ArgumentList.WithArguments(replacementArguments));

        var newRoot = root.ReplaceNode(invocation, newInvocation);
        return document.WithSyntaxRoot(newRoot);
    }
}
