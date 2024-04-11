namespace Hussy.Net;

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
        Func<int, int, TSource, TResult> mappingFunction)
    {
        var sequence = source.ToList();
        var results = new List<TResult>(capacity: sequence.Count * sequence.Count);
        for (var x = 0; x < sequence.Count; x++)
        for (var y = 0; y < sequence.Count; y++)
        {
            var result = mappingFunction(x, y, sequence[x]);
            results.Add(result);
        }

        return results;
    }
}