namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    [Fact]
    public void TestCaseTwo_Passes()
    {
        const int input = -121;
        RunTest(expectedResult: false, input);
    }
}