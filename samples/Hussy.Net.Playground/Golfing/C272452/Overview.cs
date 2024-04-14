namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "fizz fizz fizz buzz" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/272452/fizzfizzfizzbuzz"/>
public sealed partial class C272452
{
    /// <summary>
    ///     <para>
    ///         Given a positive integer <paramref name="target"/>, output
    ///         the "<b>FizzFizzFizzBuzz</b>" value for that number.
    ///     </para>
    ///     <para>
    ///         <b>Requirements:</b>
    ///         <list type="bullet">
    ///             <item>
    ///                 If the number is divisible by both <c>3</c> <i>and</i> <c>5</c>,
    ///                 instead of the number, output <c>Fizz</c> the number of times
    ///                 it can be divided by <c>3</c>, then <c>Buzz</c> the number of
    ///                 times it can be divided by <c>5</c>.
    ///             </item>
    ///             <item>
    ///                 If the number is divisible by <c>3</c>, instead of the number,
    ///                 output <c>Fizz</c> the number of times it can be divided by <c>3</c>.
    ///             </item>
    ///             <item>
    ///                 If the number is divisible by <c>5</c>, instead of the number,
    ///                 output <c>Buzz</c> the number of times it can be divided by <c>5</c>.
    ///             </item>
    ///             <item>
    ///                 Otherwise, output the number itself.
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    /// <param name="target">The stopping value for the test.</param>
    /// <returns>
    ///     A collection of strings representing the output for the specified <paramref name="target"/>.
    /// </returns>
    private delegate IEnumerable<string> TestFunction(int target);
}