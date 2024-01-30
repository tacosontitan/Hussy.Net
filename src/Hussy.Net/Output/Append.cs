namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="value">The value to write.</param>
    public static void A<T>(T value) =>
        Console.Write(value);
}