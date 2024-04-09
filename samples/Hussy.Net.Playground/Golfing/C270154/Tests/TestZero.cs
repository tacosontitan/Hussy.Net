namespace Hussy.Net.Playground.Golfing;

/// <summary>
/// Represents a solution and its tests for the "Strings without twin letters" challenge on Code Golf SE.
/// </summary>
/// <see href="https://codegolf.stackexchange.com/questions/270154/strings-without-twin-letters"/>
public sealed partial class C270154
{
    [Theory]
    [InlineData("", 1)]
    [InlineData("A", 2)]
    [InlineData("AAB", 7)]
    [InlineData("ABB", 7)]
    [InlineData("ABCA", 7)]
    public void InvalidInput_ReturnsEmpty(string characters, int length)
    {
        var expectedResult = Array.Empty<string>();
        RunTest(expectedResult, characters, length);
    }
}