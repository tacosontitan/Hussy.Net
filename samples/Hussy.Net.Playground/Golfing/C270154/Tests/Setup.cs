namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    /// <summary>
    /// Gets the functions the tests should be applied to.
    /// </summary>
    private static TestFunction[] TestFunctions =>
    [
        DryRun
    ];
    
    /// <summary>
    /// Tests all runs to ensure each has the same expected result.
    /// </summary>
    private static void RunTest(
        IEnumerable<string> expectedResults,
        string characters,
        int length)
    {
        var expectedSequence = expectedResults.ToList();
        foreach (var testFunction in TestFunctions)
        {
            var results = testFunction(characters, length);
            var resultingSequence = results.ToList();

            var excessResults = resultingSequence.Except(expectedSequence);
            Assert.True(expectedSequence.All(resultingSequence.Contains));
            Assert.Empty(excessResults);
        }
    }
}