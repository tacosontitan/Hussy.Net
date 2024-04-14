namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    [Fact]
    public void TestCaseOne_Passes()
    {
        const int input = 121;
        RunTest(expectedResult: true, input);
    }
}