namespace Hussy.Net.Playground.AdventOfCode.Y2024;

/// <summary>
/// Defines implementations and tests for day two of Advent of Code in 2024.
/// </summary>
public sealed partial class DayTwo
{
    /// <summary>
    ///     Determines how many reports consist of safe levels. A report is considered
    ///     representative of safe levels if both of the following criteria are met:
    ///
    ///     <ul>
    ///         <li>The levels are either all increasing or all decreasing.</li>
    ///         <li>Any two adjacent levels differ by at least one and at most three.</li>
    ///     </ul>
    /// </summary>
    /// <param name="reports">The reports to analyze with the solution.</param>
    /// <returns>The number of reports consisting of safe levels.</returns>
    private delegate int Solution(IEnumerable<int[]> reports);
}