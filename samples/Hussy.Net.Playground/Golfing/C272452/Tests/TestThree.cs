namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    [Fact]
    public void TestCaseThree_Passes()
    {
        const int target = 6;
        string[] expectedResults =
        [
            "1", "2", "Fizz",
            "4", "Buzz", "Fizz"
        ];
        
        RunTests(expectedResults, target);
    }
}