namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    /// <summary>
    /// A very mundane approach to solving the problem to better understand the solution components.
    /// </summary>
    private static IEnumerable<string> DryRun(string characters, int length)
    {
        if (characters.Length < 2)
            return Array.Empty<string>();
        
        if (characters.Any(IsDuplicated))
            return Array.Empty<string>();
        
        var result = characters.Select(c => c.ToString()).ToList();

        for (int i = 1; i < length; i++)
        {
            var temp = new List<string>();
            foreach (var prefix in result)
            {
                foreach (var nextChar in characters)
                {
                    if (nextChar != prefix.LastOrDefault())
                    {
                        temp.Add(prefix + nextChar);
                    }
                }
            }

            result = temp;
        }

        bool IsDuplicated(char c) =>
            characters.Count(d => char.ToUpper(c) == char.ToUpper(d)) > 1;

        return result;
    }
}