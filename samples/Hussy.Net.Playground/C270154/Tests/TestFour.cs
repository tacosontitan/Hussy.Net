namespace Hussy.Net.Playground;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseFour_Passes()
    {
        var length = 2;
        var characters = "OKAY";
        var expectedResult = new[]
        {
            "OK", "OA", "OY", "KO", "KA", "KY", "AO", "AK", "AY", "YO", "YK", "YA"
        };

        RunTest(expectedResult, characters, length);
    }
}