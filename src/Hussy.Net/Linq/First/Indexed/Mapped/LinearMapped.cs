namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Gets and maps the first element of the source collection.
    /// </summary>
    /// <param name="source">The source collection to get the first element from.</param>
    /// <param name="predicate">A predicate which determines if the element is a match.</param>
    /// <param name="mappingFunction">A function for mapping the matched predicate data to the intended result.</param>
    /// <typeparam name="TSource">Specifies the type of data within the collection.</typeparam>
    /// <typeparam name="TResult">Specifies the type of the result of the mapping function.</typeparam>
    /// <returns>
    ///     The first element in the collection matching the predicate,
    ///     mapped with the specified mapping function.
    /// </returns>
    public static TResult? Fe<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<Indexed<TSource>, bool> predicate,
        Func<Indexed<TSource>, TResult> mappingFunction)
    {
        var index = 0;
        var sequence = source.ToList();
        foreach (var element in sequence)
        {
            var indexedElement = new Indexed<TSource>(index, element);
            if (predicate(indexedElement))
            {
                var result = mappingFunction(indexedElement);
                return result;
            }
        }

        return default;
    }
}