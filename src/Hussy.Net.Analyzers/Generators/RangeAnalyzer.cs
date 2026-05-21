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
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Hussy.Net.Analyzers.Generators;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class RangeAnalyzer : DiagnosticAnalyzer
{
    public const string DiagnosticId = "HN0002";

    private static readonly LocalizableString Title = new LocalizableResourceString(
        nameof(Resources.HN0002Title), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString MessageFormat = new LocalizableResourceString(
        nameof(Resources.HN0002MessageFormat), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString Description = new LocalizableResourceString(
        nameof(Resources.HN0002Description), Resources.ResourceManager, typeof(Resources));

    private const string Category = "Style";

    public static readonly DiagnosticDescriptor Rule = new(
        DiagnosticId, Title, MessageFormat, Category,
        DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterOperationAction(AnalyzeOperation, OperationKind.Invocation);
    }

    private static void AnalyzeOperation(OperationAnalysisContext context)
    {
        if (context.Operation is not IInvocationOperation invocationOperation)
            return;

        var methodSymbol = invocationOperation.TargetMethod;
        if (methodSymbol.Name != nameof(Enumerable.Range) ||
            methodSymbol.Parameters.Length != 2 ||
            methodSymbol.TypeParameters.Length != 0 ||
            !methodSymbol.IsStatic ||
            methodSymbol.ContainingType?.Name != nameof(Enumerable) ||
            methodSymbol.ContainingNamespace?.ToDisplayString() != "System.Linq" ||
            IsHussySimpleRangeImplementation(context.ContainingSymbol) ||
            invocationOperation.Syntax is not InvocationExpressionSyntax invocationSyntax)
            return;

        var diagnostic = Diagnostic.Create(Rule, invocationSyntax.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }

    private static bool IsHussySimpleRangeImplementation(ISymbol? symbol) =>
        symbol is IMethodSymbol
        {
            Name: "Gr",
            ContainingType:
            {
                Name: "Hussy",
                ContainingNamespace: { } containingNamespace
            }
        }
        && containingNamespace.ToDisplayString() == "Hussy.Net";
}
