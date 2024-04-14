namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    ///     The second golf run employs a <see langword="for"/> loop
    ///     to leverage inline allocation, conditional execution,
    ///     and iteration instructions.
    /// </summary>
    /// <param name="i">The input value to evaluate.</param>
    /// <returns>
    ///     <see langword="true"/> if the input is a palindrome;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    ///     Fully condensed, this method body becomes <c>62</c> bytes.
    /// </remarks>
    private static bool GolfedDryRunV2(int i)
    {
        int t = i, r = t % 10;
        for (;t / 10 > 0;)
            r = r * 10 + (t /= 10) % 10;

        return r > 0 && r == i;
    }
}