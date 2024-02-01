namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Applies a mapping function to each element in the source enumerable and returns an enumerable
    /// containing the result of the mapping.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source enumerable.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the resulting enumerable.</typeparam>
    /// <param name="source">The source enumerable.</param>
    /// <param name="mappingFunction">The mapping function to apply to each element.</param>
    /// <returns>An enumerable containing the results of the mapping.</returns>
    public static IEnumerable<TResult> M<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> mappingFunction) =>
        source.Select(mappingFunction);
}