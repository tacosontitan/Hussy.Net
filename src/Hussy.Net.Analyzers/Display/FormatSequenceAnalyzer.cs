/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0
*/

using System.Collections.Immutable;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Hussy.Net.Analyzers.Display;

/// <summary>
///     An analyzer that suggests using <c>Fsq</c> to format a sequence.
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
    }

    private static void AnalyzeInterpolatedString(SyntaxNodeAnalysisContext context)
    {
        if (context.Node is not InterpolatedStringExpressionSyntax expression ||
            IsFormatterImplementation(context.SemanticModel, expression, context.CancellationToken) ||
            !FormatSequencePattern.TryGetArguments(
                expression, context.SemanticModel, context.CancellationToken, out _, out _))
            return;

        context.ReportDiagnostic(Diagnostic.Create(Rule, expression.GetLocation()));
    }

    private static bool IsFormatterImplementation(
        SemanticModel semanticModel,
        InterpolatedStringExpressionSyntax expression,
        CancellationToken cancellationToken)
    {
        if (semanticModel.GetEnclosingSymbol(expression.SpanStart, cancellationToken) is not IMethodSymbol method)
            return false;

        return method.Name == "Fsq" &&
               method.ContainingType.Name == "Hussy" &&
               method.ContainingType.ContainingNamespace.ToDisplayString() == "Hussy.Net";
    }
}
