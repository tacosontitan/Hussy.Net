namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    [Fact]
    public void TestCaseFive_Passes() => RunTests(
        expectedResults: [" Gap ", " gAp ", " gaP "],
        input: " gap ");
}