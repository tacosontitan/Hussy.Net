namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    /// Gets the functions the tests should be applied to.
    /// </summary>
    private static TestFunction[] TestFunctions =>
    [
        DryRun
    ];
    
    /// <summary>
    /// Tests all runs to ensure each has the same expected result.
    /// </summary>
    private static void RunTest(
        IEnumerable<int> expectedResults,
        int[] numbers,
        int target)
    {
        var expectedSequence = expectedResults.ToList();
        foreach (var testFunction in TestFunctions)
        {
            var results = testFunction(numbers, target);
            var resultingSequence = results.ToList();

            var excessResults = resultingSequence.Except(expectedSequence);
            Assert.True(expectedSequence.All(resultingSequence.Contains));
            Assert.Empty(excessResults);
        }
    }
}