namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Writes the specified value to the console as a header (prefixed with two new lines).
    /// </summary>
    /// <param name="value">The value to be written.</param>
    public static void WH<T>(T value) =>
        Console.WriteLine("\n\n{0}", value);
}