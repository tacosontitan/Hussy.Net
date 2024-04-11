namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Gets the index of the specified element within the source collection.
    /// </summary>
    /// <param name="source">The source collection to look through.</param>
    /// <param name="element">The element to look for.</param>
    /// <typeparam name="T">Specifies the type of data within the source collection.</typeparam>
    /// <returns>
    ///     The index of the element within the collection if found;
    ///     otherwise <c>-1</c>.
    /// </returns>
    public static int I<T>(
        this IEnumerable<T> source,
        T element)
    {
        var sequence = source.ToList();
        for (var index = 0; index < sequence.Count; index++)
        {
            var elementAtIndex = sequence[index];
            if (element.Equals(elementAtIndex))
                return index;
        }

        return -1;
    }
}