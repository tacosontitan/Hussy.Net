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
    /// <remarks>
    ///     Fully condensed, this method body becomes <c>93</c> bytes.
    /// </remarks>
    private static IEnumerable<int> GolfedDryRun(
        int[] n,
        int t)
    {
        for (int x = 0, l = n.Length; x < l; x++)
        for (int y = 1; x != y & y < l; y++)
            if (n[x] + n[y] == t)
                return [x, y];

        return [];
    }
}