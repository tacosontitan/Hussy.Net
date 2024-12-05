using System.Text;

namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    private static List<string> DryRun(string input)
    {
        var currentIndex = 0;
        var results = new List<string>(capacity: input.Length);
        foreach (var c in input)
        {
            var result = new StringBuilder(input) { [currentIndex++] = char.ToUpper(c) }.ToString();
            if (result == input)
                continue;

            results.Add(result);
        }

        return results;
    }
}