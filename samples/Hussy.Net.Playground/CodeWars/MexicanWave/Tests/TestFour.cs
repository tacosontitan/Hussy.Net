namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    [Fact]
    public void TestCaseFour_Passes() => RunTests(
        expectedResults: ["Two words", "tWo words", "twO words", "two Words", "two wOrds", "two woRds", "two worDs", "two wordS"],
        input: "two words");
}