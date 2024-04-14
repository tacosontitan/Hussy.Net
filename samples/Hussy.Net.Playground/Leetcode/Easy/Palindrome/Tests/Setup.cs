namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    /// Gets the functions the tests should be applied to.
    /// </summary>
    private static TestFunction[] TestFunctions =>
    [
        DryRun,
        GolfedDryRun,
        HussyDryRun
    ];

    /// <summary>
    /// Tests all runs to ensure each has the same expected result.
    /// </summary>
    private static void RunTest(
        bool expectedResult,
        int input)
    {
        foreach (var isPalindrome in TestFunctions.Select(IsPalindrome))
            Assert.Equal(expectedResult, isPalindrome);

        bool IsPalindrome(TestFunction testFunction) =>
            testFunction(input);
    }
}