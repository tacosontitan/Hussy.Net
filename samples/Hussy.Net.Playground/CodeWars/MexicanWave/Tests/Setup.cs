using System.Collections.Immutable;

namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    /// <summary>
    /// Gets the functions the tests should be applied to.
    /// </summary>
    private static ImmutableArray<TestFunction> TestFunctions =>
    [
        DryRun,
        LinqRun
    ];

    private static void RunTests(
        List<string> expectedResults,
        string input)
    {
        foreach (var testFunction in TestFunctions)
        {
            var actualResults = testFunction(input);
            Assert.Equal(expectedResults, actualResults);
        }
    }
}