namespace Hussy.Net.Playground;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseOne_Passes()
    {
        var length = 3;
        var characters = "ABC";
        var expectedResult = new[]
        {
            "ABA", "ABC", "ACA", "ACB",
            "BAB", "BAC", "BCA", "BCB",
            "CAB", "CAC", "CBA", "CBC"
        };

        RunTest(expectedResult, characters, length);
    }
}