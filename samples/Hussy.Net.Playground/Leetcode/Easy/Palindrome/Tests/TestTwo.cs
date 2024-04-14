namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    ///     The number <c>-121</c> is not considered a palindrome
    ///     because reversal places the negative sign on the
    ///     opposite side without a match.
    /// </summary>
    [Fact]
    public void TestCaseTwo_Passes()
    {
        const int input = -121;
        RunTest(expectedResult: false, input);
    }
}