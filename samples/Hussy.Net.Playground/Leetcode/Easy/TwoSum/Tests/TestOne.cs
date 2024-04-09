namespace Hussy.Net.Playground.Leetcode.Easy;

/// <summary>
/// Represents a solution and its tests for the leetcode two-sum problem.
/// </summary>
/// <see href="https://leetcode.com/problems/two-sum/description/"/>
public sealed partial class TwoSum
{
    /// <summary>
    ///     The first example given on Leetcode comes with the explanation that
    ///     the numbers <c>2</c> and <c>7</c> which are located at indices <c>0</c>
    ///     and <c>1</c>, respectively, add up to the specified target value of
    ///     <c>9</c> so the expected output is <c>[0, 1]</c>.
    /// </summary>
    [Fact]
    public void TestCaseOne_Passes() => RunTest(
        expectedResults: [0, 1],
        numbers: [2, 7, 11, 15],
        target: 9);
}