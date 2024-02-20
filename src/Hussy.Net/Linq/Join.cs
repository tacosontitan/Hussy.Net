namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    public static string J<T>(this IEnumerable<T> source, string separator = ", ") =>
        string.Join(separator, source);
}