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
    public static IEnumerable<T> E<T>(
        this IEnumerable<T> source,
        Action<int, T> action)
    {
        var index = 0;
        var elements = source.ToList();
        foreach (var element in elements)
            action(index++, element);

        return elements;
    }
}