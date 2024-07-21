using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hussy.Net.Tests.Display;

public class FormatArrayTests
{
    [Fact]
    public void FormatSequence_Null_ReturnsEmptyBrackets()
    {
        const string expectedResult = "[]";
        var actualResult = Fsq<int>(null);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void FormatSequence_EmptyInput_ReturnsEmptyBrackets()
    {
        const string expectedResult = "[]";
        var actualResult = Fsq<int>([]);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void FormatSequence_SequenceContainsElements_ReturnsElementsWrappedInBrackets()
    {
        const string expectedResult = "[1, 2, 3]";
        var input = Enumerable.Range(1, 3);
        var actualResult = Fsq(input);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void FormatSequence_SpecifiedSeparator_ReturnsElementsWithSeparator()
    {
        const string separator = ":";
        const string expectedResult = $"[1{separator}2]";
        var input = Enumerable.Range(1, 2);
        var actualResult = Fsq(input, separator);
        Assert.Equal(expectedResult, actualResult);
    }
}