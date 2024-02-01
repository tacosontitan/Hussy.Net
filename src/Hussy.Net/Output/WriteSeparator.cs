namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Writes a separator line of specified character and length to the console.
    /// </summary>
    /// <param name="character">The character used for the separator line. Default is '='.</param>
    /// <param name="length">The length of the separator line. Default is 25.</param>
    public static void WS(char character = '=', int length = 25)
    {
        var separator = new string(character, length);
        Console.WriteLine(separator);
    }
}