namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    ///     The number <c>10</c> is not a palindrome because it is a
    ///     two digit number where both digits are the same.
    /// </summary>
    [Fact]
    public void TestCaseThree_Passes()
    {
        const int input = 10;
        RunTest(expectedResult: false, input);
    }
}