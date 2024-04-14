namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    [Fact]
    public void TestCaseThree_Passes()
    {
        const int input = 10;
        RunTest(expectedResult: false, input);
    }
}