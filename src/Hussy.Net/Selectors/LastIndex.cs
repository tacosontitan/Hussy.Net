namespace Hussy.Net.Selectors;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Gets the accessible index in the specified <paramref name="source"/> collection.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data within the <paramref name="source"/> collection.</typeparam>
    /// <param name="source">The collection to get the last index for.</param>
    /// <returns>The accessible index in the specified <paramref name="source"/> collection.</returns>
    public static int L<T>(IEnumerable<T> source)
    {
        var count = source.Count() - 1;
        return count;
    }
}