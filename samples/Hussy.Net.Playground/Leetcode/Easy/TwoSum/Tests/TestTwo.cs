namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    [Fact]
    public void TestCaseTwo_Passes() => RunTest(
        expectedResults: [1, 2],
        numbers: [3, 2, 4],
        target: 6);
}