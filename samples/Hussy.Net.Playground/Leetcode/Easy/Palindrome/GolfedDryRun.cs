namespace Hussy.Net.Playground.Leetcode.Easy;

public sealed partial class Palindrome
{
    /// <summary>
    ///     The initial golf run simply compresses the dry run.
    /// </summary>
    /// <param name="i">The input value to evaluate.</param>
    /// <returns>
    ///     <see langword="true"/> if the input is a palindrome;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    private static bool GolfedDryRun(int i)
    {
        if (i < 0)
            return false;

        if (i / 10 == 0)
            return true;

        int t = i, r = t % 10;
        while (t / 10 > 0)
            r = r * 10 + (t /= 10) % 10;

        return r == i;
    }
}