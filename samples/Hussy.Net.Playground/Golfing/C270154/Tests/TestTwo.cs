namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseTwo_Passes()
    {
        var length = 3;
        var characters = "AB";
        var expectedResult = new[]
        {
            "ABA", "BAB"
        };

        RunTest(expectedResult, characters, length);
    }
}