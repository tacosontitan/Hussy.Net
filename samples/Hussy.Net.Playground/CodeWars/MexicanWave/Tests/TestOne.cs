namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    [Fact]
    public void TestCaseOne_Passes() => RunTests(
        expectedResults: ["Hello", "hEllo", "heLlo", "helLo", "hellO"],
        input: "hello");
}