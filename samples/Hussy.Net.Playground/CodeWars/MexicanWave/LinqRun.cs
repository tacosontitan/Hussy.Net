using System.Text;

namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    private static List<string> LinqRun(string input) => input
        .Select((c, i) => new StringBuilder(input) { [i] = char.ToUpper(c) }.ToString())
        .Where(result => result != input)
        .ToList();
}