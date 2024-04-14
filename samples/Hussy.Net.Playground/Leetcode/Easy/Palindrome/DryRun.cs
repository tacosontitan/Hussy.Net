namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    private static bool DryRun(int input)
    {
        if (input < 0)
            return false;

        var reversal = 0;
        var testValue = input;
        while (testValue > 0)
        {
            var lastDigit = testValue % 10;
            reversal = reversal * 10 + lastDigit;
            testValue /= 10;
        }

        return reversal == input;
    }
}