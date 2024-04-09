namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    /// <summary>
    /// Tackles the problem using just LINQ methods.
    /// </summary>
    private static IEnumerable<string> LinqRun(string characters, int length) => Enumerable.Range(1, length - 1)
        .Aggregate(characters.Select(c => c.ToString()), (current, _) =>
            current.SelectMany(prefix =>
                    characters.Where(c => c != prefix.LastOrDefault()),
                (prefix, nextChar) => prefix + nextChar));
}