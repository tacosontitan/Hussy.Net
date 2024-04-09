namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Fact]
    public void TestCaseThree_Passes()
    {
        var length = 3;
        var characters = "ABCD";
        var expectedResult = new[]
        {
            "ABA", "ABC", "ABD", "ACA", "ACB", "ACD", "ADA", "ADB", "ADC", "BAB", "BAC", "BAD", "BCA", "BCB", "BCD",
            "BDA", "BDB", "BDC", "CAB", "CAC", "CAD", "CBA", "CBC", "CBD", "CDA", "CDB", "CDC", "DAB", "DAC", "DAD",
            "DBA", "DBC", "DBD", "DCA", "DCB", "DCD"
        };

        RunTest(expectedResult, characters, length);
    }
}