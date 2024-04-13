namespace Hussy.Net.Tests.Primitives;

public sealed class NumberTests
{
    [Fact]
    public void EqualsByte_Equal_ReturnsTrue()
    {
        const byte testValue = 5;
        Number sample = testValue;
        Assert.True(sample.Equals(testValue));
    }

    [Fact]
    public void EqualsByte_NotEqual_ReturnsFalse()
    {
        const byte testValue = 3;
        Number sample = testValue;
        Assert.Equal(testValue, sample);

        const byte comparisonValue = 5;
        Assert.NotEqual(comparisonValue, sample);
    }
}