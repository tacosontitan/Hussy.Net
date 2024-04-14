namespace Hussy.Net.Tests.Display;

public class ReverseTests
{
    [Fact]
    public void Reverse_ValidInput_ReversesInput()
    {
        const string testValue = "abc";
        var reversal = Rev(testValue);

        const string expectation = "cba";
        Assert.Equal(expectation, reversal);
    }
}