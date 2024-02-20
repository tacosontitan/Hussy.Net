namespace Hussy.Net.Playground;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    /// <summary>
    /// <para>
    /// Consider an arbitrary set of letters <paramref name="characters"/> which may either be
    /// <c>{A,B,C}</c>, <c>{M,N,O,P}</c>, <c>{N,F,K,D}</c>, or even contain all the 26 letters.
    /// </para>
    /// <para>
    /// Given an instance of <paramref name="characters"/> and a positive integer <paramref name="length"/>,
    /// how many <paramref name="length"/>-letter words can we build from <paramref name="characters"/>
    /// such that no adjacent letters are the same (so for example <c>ABBC</c> is not allowed from <c>{A,B,C}</c>)?
    /// </para>
    /// </summary>
    /// <param name="characters">Specifies the arbitrary set of characters to generate the output with.</param>
    /// <param name="length">Specifies the desired length of each output string.</param>
    /// <returns>
    /// A collection of all <see cref="string"/> instances of the specified <paramref name="length"/>
    /// that can be formed from the specified <paramref name="characters"/> such that
    /// no adjacent letters are the same.
    /// </returns>
    /// <remarks>
    /// The number of words can be solved using combinatorics, but what those words are?
    /// </remarks>
    private delegate IEnumerable<string> TestFunction(string characters, int length);
}