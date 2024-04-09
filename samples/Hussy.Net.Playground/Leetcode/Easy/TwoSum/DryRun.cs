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
    /// <param name="numbers">The array of numbers to look through.</param>
    /// <param name="target">
    ///     The target number which the two numbers in <paramref name="numbers"/> must add up to.
    /// </param>
    /// <returns>
    ///     The two indices of the numbers which add up to the <paramref name="target"/>.
    /// </returns>
    private static IEnumerable<int> DryRun(
        int[] numbers,
        int target)
    {
        for (var x = 0; x < numbers.Length; x++)
        {
            for (var y = 0; y < numbers.Length; y++)
            {
                if (x == y)
                    continue;

                var a = numbers[x];
                var b = numbers[y];
                if (a + b == target)
                    return [x, y];
            }
        }

        return Enumerable.Empty<int>();
    }
}