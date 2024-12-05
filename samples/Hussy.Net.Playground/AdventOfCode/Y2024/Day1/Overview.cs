namespace Hussy.Net.Playground.AdventOfCode.Y2024;

/// <summary>
/// Defines implementations and tests for day one of Advent of Code in 2024.
/// </summary>
public sealed partial class DayOne
{
    /// <summary>
    ///     Determines the distance between the two specified lists as defined in the problem
    ///     statement for day one's challenge.
    /// </summary>
    public delegate int Solution(
        IEnumerable<int> leftList,
        IEnumerable<int> rightList);
}