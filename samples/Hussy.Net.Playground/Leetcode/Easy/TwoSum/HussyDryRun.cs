namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    /// A very mundane and direct approach to solving the problem to understand where Hussy may be lacking.
    /// </summary>
    /// <param name="n">The array of numbers to look through.</param>
    /// <param name="t">
    ///     The target number which the two numbers in <paramref name="n"/> must add up to.
    /// </param>
    /// <returns>
    ///     The two indices of the numbers which add up to the <paramref name="t"/>.
    /// </returns>
    /// <remarks>
    ///     Fully condensed, this method body becomes <c>55</c> bytes.
    /// </remarks>
    private static IEnumerable<int>? HussyDryRun(
        int[] n,
        int t) =>
        n.Fe(
            (x, y) => x.I != y.I && x.V + y.V == t,
            (x, y) => new[] { x.I, y.I }
        );
}