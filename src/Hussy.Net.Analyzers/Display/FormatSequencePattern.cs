/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0
*/

using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

namespace Hussy.Net.Analyzers.Display;

internal static class FormatSequencePattern
{
    internal static bool TryGetArguments(
        InterpolatedStringExpressionSyntax expression,
        SemanticModel semanticModel,
        CancellationToken cancellationToken,
        out ExpressionSyntax sequence,
        out ExpressionSyntax separator)
    {
        sequence = null!;
        separator = null!;

        if (expression.Contents.Count != 3 ||
            expression.Contents[0] is not InterpolatedStringTextSyntax openingText ||
            openingText.TextToken.ValueText != "[" ||
            expression.Contents[1] is not InterpolationSyntax interpolation ||
            interpolation.AlignmentClause is not null ||
            interpolation.FormatClause is not null ||
            expression.Contents[2] is not InterpolatedStringTextSyntax closingText ||
            closingText.TextToken.ValueText != "]" ||
            interpolation.Expression is not InvocationExpressionSyntax invocation ||
            semanticModel.GetOperation(invocation, cancellationToken) is not IInvocationOperation operation ||
            !TryGetFormatterArgumentOrdinals(
                operation.TargetMethod, out var sequenceOrdinal, out var separatorOrdinal) ||
            operation.Arguments.Length != operation.TargetMethod.Parameters.Length)
            return false;

        IArgumentOperation? sequenceArgument = null;
        IArgumentOperation? separatorArgument = null;

        foreach (var argument in operation.Arguments)
        {
            if (argument.Parameter?.Ordinal == separatorOrdinal)
                separatorArgument = argument;
            else if (argument.Parameter?.Ordinal == sequenceOrdinal)
                sequenceArgument = argument;
        }

        if (sequenceArgument?.Syntax is not ArgumentSyntax sequenceSyntax ||
            separatorArgument?.Syntax is not ArgumentSyntax separatorSyntax)
            return false;

        var separatorValue = semanticModel.GetConstantValue(
            separatorSyntax.Expression, cancellationToken);
        if (separatorValue is { HasValue: true, Value: null } ||
            semanticModel.GetTypeInfo(separatorSyntax.Expression, cancellationToken).Type?.NullableAnnotation ==
            NullableAnnotation.Annotated)
            return false;

        sequence = sequenceSyntax.Expression;
        separator = separatorSyntax.Expression;
        return true;
    }

    private static bool TryGetFormatterArgumentOrdinals(
        IMethodSymbol method,
        out int sequenceOrdinal,
        out int separatorOrdinal)
    {
        sequenceOrdinal = -1;
        separatorOrdinal = -1;

        if (method.Name != nameof(string.Join) ||
            method.ContainingType.SpecialType != SpecialType.System_String ||
            method.Parameters.Length != 2 ||
            method.Parameters[0].Type.SpecialType != SpecialType.System_String)
            return false;

        var sequenceType = method.Parameters[1].Type;
        if (sequenceType is not IArrayTypeSymbol &&
            (sequenceType is not INamedTypeSymbol namedType ||
             namedType.OriginalDefinition.MetadataName != "IEnumerable`1" ||
             namedType.ContainingNamespace.ToDisplayString() != "System.Collections.Generic"))
            return false;

        separatorOrdinal = 0;
        sequenceOrdinal = 1;
        return true;
    }
}
