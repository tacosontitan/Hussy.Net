namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Determines if an integer <paramref name="input"/> is a palindrome.
    /// </summary>
    /// <param name="input">The <see cref="int"/> instance to evaluate.</param>
    /// <returns>
    ///     <see langword="true"/> if the number is a palindrome;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    /// <see href="https://en.wikipedia.org/wiki/Palindrome"/>
    public static bool Pal(int input)
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