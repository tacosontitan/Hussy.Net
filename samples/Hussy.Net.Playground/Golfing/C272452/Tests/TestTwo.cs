namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    [Fact]
    public void TestCaseTwo_Passes()
    {
        const int target = 3;
        string[] expectedResults = ["0", "1", "2", "Fizz"];
        RunTests(expectedResults, target);
    }
}