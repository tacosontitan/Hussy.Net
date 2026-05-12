using JetBrains.Annotations;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Hussy.Net.Tests.Linq;

[TestSubject(typeof(Hussy))]
public class FilterTests
{
    [Fact]
    public void Filter_MatchingElementsExist_ReturnsElementsThatMatchPredicate()
    {
        var source = Enumerable.Range(1, 10);
        var actualResult = source.F(value => value % 2 == 0);
        var expectedResult = source.Where(value => value % 2 == 0);
        Assert.Equal(expectedResult, actualResult);
    }
    
    [Fact]
    public void Filter_NoElementsMatchPredicate_ReturnsEmptySequence()
    {
        var source = Enumerable.Range(1, 5);
        var actualResult = source.F(value => value > 5);
        Assert.Empty(actualResult);
    }
}
