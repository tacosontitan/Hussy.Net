namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static class Hussy
{
    /// <summary>
    /// Writes the specified value, followed by the current line terminator, to the standard output stream.
    /// </summary>
    /// <param name="value">The value to write.</param>
    public static void W<T>(T value) =>
        Console.WriteLine(value);
}