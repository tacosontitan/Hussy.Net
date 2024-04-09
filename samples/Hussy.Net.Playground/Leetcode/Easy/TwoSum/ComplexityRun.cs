using Glitter.Collections;

namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    ///     A direct approach to solving the problem with less time complexity
    ///     to understand where Hussy may be lacking.
    /// </summary>
    /// <param name="numbers">The array of numbers to look through.</param>
    /// <param name="target">
    ///     The target number which the two numbers in <paramref name="numbers"/> must add up to.
    /// </param>
    /// <returns>
    ///     The two indices of the numbers which add up to the <paramref name="target"/>.
    /// </returns>
    private static IEnumerable<int> ComplexityRun(
        int[] numbers,
        int target)
    {
        var seen = new Dictionary<int, int>();
        for (var i = 0; i < numbers.Length; i++)
        {
            var currentNumber = numbers[i];
            var complement = target - currentNumber;
            if (seen.TryGetValue(complement, out var value))
                return [value, i];
            
            seen[currentNumber] = i;
        }

        return Enumerable.Empty<int>();
    }
}