namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    private static TestFunction[] TestFunctions =>
    [
        DryRun,
        GolfedDryRun
    ];

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