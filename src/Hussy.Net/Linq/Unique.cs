namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Gets the unique elements in the collection.
    /// </summary>
    /// <param name="source">The collection to get unique elements from.</param>
    /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
    /// <returns>The unique elements in the collection.</returns>
    public static IEnumerable<T> U<T>(this IEnumerable<T> source) =>
        source.Distinct();
}