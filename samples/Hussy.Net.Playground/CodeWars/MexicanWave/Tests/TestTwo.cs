namespace Hussy.Net.Playground.CodeWars;

public sealed partial class MexicanWave
{
    [Fact]
    public void TestCaseTwo_Passes() => RunTests(
        expectedResults: ["Codewars", "cOdewars", "coDewars", "codEwars", "codeWars", "codewArs", "codewaRs", "codewarS"],
        input: "codewars");
}