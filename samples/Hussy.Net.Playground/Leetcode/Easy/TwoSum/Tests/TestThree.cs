namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    [Fact]
    public void TestCaseThree_Passes() => RunTest(
        expectedResults: [0, 1],
        numbers: [3, 3],
        target: 6);
}