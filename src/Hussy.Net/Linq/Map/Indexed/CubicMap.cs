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
        Func<Indexed<TSource>, Indexed<TSource>, Indexed<TSource>, TResult> mappingFunction)
    {
        var sequence = source.ToList();
        var results = new List<TResult>(capacity: sequence.Count * sequence.Count * sequence.Count);
        for (var x = 0; x < sequence.Count; x++)
        for (var y = 0; y < sequence.Count; y++)
        for (var z = 0; z < sequence.Count; z++)
        {
            var indexedX = new Indexed<TSource>(x, sequence[x]);
            var indexedY = new Indexed<TSource>(y, sequence[y]);
            var indexedZ = new Indexed<TSource>(z, sequence[z]);
            var result = mappingFunction(indexedX, indexedY, indexedZ);
            results.Add(result);
        }

        return results;
    }
}