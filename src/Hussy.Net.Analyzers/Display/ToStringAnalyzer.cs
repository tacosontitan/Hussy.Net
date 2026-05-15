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
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Hussy.Net.Analyzers.Display;

/// <summary>
///     An analyzer that reports calls to <see cref="object.ToString"/> and
///     suggests using the <c>Ts</c> shorthand method instead.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class ToStringAnalyzer : DiagnosticAnalyzer
{
    /// <summary>
    ///     The diagnostic ID for this analyzer.
    /// </summary>
    public const string DiagnosticId = "HN0001";

    private static readonly LocalizableString Title = new LocalizableResourceString(
        nameof(Resources.HN0001Title), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString MessageFormat = new LocalizableResourceString(
        nameof(Resources.HN0001MessageFormat), Resources.ResourceManager, typeof(Resources));

    private static readonly LocalizableString Description = new LocalizableResourceString(
        nameof(Resources.HN0001Description), Resources.ResourceManager, typeof(Resources));

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
        context.RegisterOperationAction(AnalyzeOperation, OperationKind.Invocation);
    }

    private static void AnalyzeOperation(OperationAnalysisContext context)
    {
        if (context.Operation is not IInvocationOperation invocationOperation)
            return;

        var methodSymbol = invocationOperation.TargetMethod;

        // Only match the parameterless, non-generic instance ToString() method.
        if (methodSymbol.Name != nameof(ToString) ||
            methodSymbol.Parameters.Length != 0 ||
            methodSymbol.TypeParameters.Length != 0 ||
            methodSymbol.IsStatic ||
            invocationOperation.Arguments.Length != 0)
            return;

        // Only match explicit member access expressions (e.g. x.ToString()),
        // excluding base access (e.g. base.ToString()).
        if (invocationOperation.Syntax is not InvocationExpressionSyntax invocationSyntax)
            return;

        if (invocationSyntax.Expression is not MemberAccessExpressionSyntax memberAccess)
            return;

        if (memberAccess.Expression is BaseExpressionSyntax)
            return;

        var diagnostic = Diagnostic.Create(Rule, invocationSyntax.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }
}
