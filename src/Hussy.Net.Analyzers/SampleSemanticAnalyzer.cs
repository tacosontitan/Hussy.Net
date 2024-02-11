using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Hussy.Net.Analyzers;

/// <summary>
/// A sample analyzer that reports invalid values being used for the 'speed' parameter of the 'SetSpeed' function.
/// To make sure that we analyze the method of the specific class, we use semantic analysis instead of the syntax tree, so this analyzer will not work if the project is not compilable.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class SampleSemanticAnalyzer
    : DiagnosticAnalyzer
{
    private const string Category = "Golfing";
    private const string DiagnosticId = "HUSSY0001";
    private const string CommonApiClassName = "Console";
    private const string CommonApiMethodName = "WriteLine";
    
    private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.HUSSY0001Title),
        Resources.ResourceManager, typeof(Resources));
    
    private static readonly LocalizableString MessageFormat =
        new LocalizableResourceString(nameof(Resources.HUSSY0001Message), Resources.ResourceManager,
            typeof(Resources));

    private static readonly LocalizableString Description =
        new LocalizableResourceString(nameof(Resources.HUSSY0001Description), Resources.ResourceManager,
            typeof(Resources));


    private static readonly DiagnosticDescriptor Rule = new(DiagnosticId, Title, MessageFormat, Category,
        DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

    // Keep in mind: you have to list your rules here.
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
        ImmutableArray.Create(Rule);

    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();
        context.RegisterOperationAction(AnalyzeOperation, OperationKind.Invocation);
    }

    /// <summary>
    /// Executed on the completion of the semantic analysis associated with the Invocation operation.
    /// </summary>
    /// <param name="context">Operation context.</param>
    private void AnalyzeOperation(OperationAnalysisContext context)
    {
        if (context.Operation is not IInvocationOperation invocationOperation ||
            context.Operation.Syntax is not InvocationExpressionSyntax invocationSyntax)
            return;

        var methodSymbol = invocationOperation.TargetMethod;

        if (methodSymbol.MethodKind != MethodKind.Ordinary ||
            methodSymbol.ReceiverType?.Name != CommonApiClassName ||
            methodSymbol.Name != CommonApiMethodName
           )
            return;

        if (invocationSyntax.ArgumentList.Arguments.Count != 1)
            return;
        
        var diagnostic = Diagnostic.Create(Rule, invocationSyntax.GetLocation());
        context.ReportDiagnostic(diagnostic);
    }
}