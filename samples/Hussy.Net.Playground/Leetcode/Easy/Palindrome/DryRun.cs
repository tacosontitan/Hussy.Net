namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    /// A very mundane approach to the problem to determine where Hussy is lacking.
    /// </summary>
    /// <param name="input">The input value to evaluate.</param>
    /// <returns>
    ///     <see langword="true"/> if the input is a palindrome;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
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