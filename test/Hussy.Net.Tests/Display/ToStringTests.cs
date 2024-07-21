namespace Hussy.Net.Tests.Display;

public class ToStringTests
{
    [Fact]
    public void ToString_NullInput_ReturnsNullLiteral()
    {
        const string expectedResult = "null";
        int? testValue = null;
        var actualResult = testValue.Ts();
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void ToString_ValidInput_ReturnsInputAsString()
    {
        const string expectedResult = "32";
        var testValue = 32;
        var actualResult = testValue.Ts();
        Assert.Equal(expectedResult, actualResult);
    }
}