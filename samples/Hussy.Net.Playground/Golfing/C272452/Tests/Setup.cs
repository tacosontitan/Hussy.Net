namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    private static TestFunction[] TestFunctions =>
    [
        DryRun,
        GolfedRun
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
            for (var i = 0; i < resultingSequence.Count; i++)
            {
                var expectation = expectedSequence[i];
                var reality = resultingSequence[i];
                Assert.True(expectation == reality,
                    $"The result `{reality}` at index `{i}` does not match the expected result `{expectation}`.");
            }

            var excessResults = resultingSequence.Except(expectedSequence);
            Assert.Empty(excessResults);
        }
    }
}