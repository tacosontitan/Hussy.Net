namespace Hussy.Net.Playground.CodeWars;

/// <summary>
/// Represents a solution and its tests for the Mexican wave problem.
/// </summary>
/// <see href="https://www.codewars.com/kata/58f5c63f1e26ecda7e000029"/>
public sealed partial class MexicanWave
{
    /// <summary>
    ///     Given an input string, return a collection of strings representing each step
    ///     of the <paramref name="input"/> string behaving as a Mexican wave where an
    ///     uppercase letter represents a person standing up.
    /// </summary>
    /// <param name="input">Specifies the input string acting as the crowd in the wave.</param>
    /// <returns>A <see cref="List{T}"/> containing each step in the wave for the given input.</returns>
    /// </remarks>
    ///     <b>Assumptions:</b>
    ///     <ol>
    ///         <li>The input string will always be lower case but maybe empty.</li>
    ///         <li>If the character in the string is whitespace then pass over it as if it was an empty seat.</li>
    ///     </ol>
    /// </remarks>
    private delegate List<string> TestFunction(string input);
}