namespace Hussy.Net.Tests.Logic;

public class EqualsReversalTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(0)]
    [InlineData(121)]
    [InlineData("abba")]
    public void EqualsReversal_InputMatchesReversal_ReturnsTrue(object testValue)
    {
        var reversalEqualsTestValue = testValue.EqRev();
        Assert.True(reversalEqualsTestValue);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData("123")]
    public void EqualsReversal_InputDoesNotMatchReversal_ReturnsFalse(object testValue)
    {
        var reversalEqualsTestValue = testValue.EqRev();
        Assert.False(reversalEqualsTestValue);
    }
}