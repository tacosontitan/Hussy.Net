namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    private static TestFunction[] TestFunctions =>
    [
        
    ];

    private static void RunTests(
        IEnumerable<string> expectedResults,
        int target)
    {
        var expectedSequence = expectedResults.ToList();
        foreach (var testFunction in TestFunctions)
        {
            var results = testFunction(target);
            var resultingSequence = results.ToList();

            var excessResults = resultingSequence.Except(expectedSequence);
            Assert.True(expectedSequence.All(resultingSequence.Contains));
            Assert.Empty(excessResults);
        }
    }
}