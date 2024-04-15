namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Applies the specified action to each element in the source collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source collection.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="action">The action to be applied to each element.</param>
    /// <returns>The source collection.</returns>
    public static IEnumerable<T> Ec<T>(
        this IEnumerable<T> source,
        Action<int, int, int, int, T> action)
    {
        var elements = source.ToList();
        for (var x = 0; x < elements.Count; x++)
        for (var y = 0; y < elements.Count; y++)
        for (var z = 0; z < elements.Count; z++)
        for (var w = 0; w < elements.Count; w++)
        {
            action(x,
                y,
                z,
                w,
                elements[x]);
        }

        return elements;
    }
}