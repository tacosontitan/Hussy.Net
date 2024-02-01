namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Filters a sequence of values based on a predicate.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <param name="source">The sequence to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>An IEnumerable{T} that contains elements from the input sequence that satisfy the condition.</returns>
    public static IEnumerable<T> F<T>(this IEnumerable<T> source, Func<T, bool> predicate) =>
        source.Where(predicate);
}