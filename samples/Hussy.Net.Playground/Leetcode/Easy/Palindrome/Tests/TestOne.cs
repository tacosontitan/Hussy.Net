namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    ///     The number <c>121</c> is considered a valid palindrome due to being
    ///     a three digit number where the outer digits (<c>1</c>) are the
    ///     same.
    /// </summary>
    [Fact]
    public void TestCaseOne_Passes()
    {
        const int input = 121;
        RunTest(expectedResult: true, input);
    }
}