namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    ///     A simple golf run to prepare for the Hussy run.
    /// </summary>
    /// <param name="n">The array of numbers to look through.</param>
    /// <param name="t">
    ///     The target number which the two numbers in <paramref name="n"/> must add up to.
    /// </param>
    /// <returns>
    ///     The two indices of the numbers which add up to the <paramref name="t"/>.
    /// </returns>
    private static IEnumerable<int> GolfedComplexityRun(
        int[] n,
        int t)
    {
        // Fully condensed, this method body becomes
        // 104 bytes.
        for (int x = 0, c = 0, i = 0, l = n.Length; x < l; x++)
        {
            c = t - n[x];
            i = Array.IndexOf(n, c, x + 1);
            if (i >= 0)
                return [x, i];
        }
        
        return [];
    }
}