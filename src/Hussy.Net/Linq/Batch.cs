namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Batches the specified <paramref name="source"/> sequence into chunks of the specified <paramref name="size"/>.
    /// </summary>
    /// <param name="source">Specifies the source sequence to batch.</param>
    /// <param name="size">Specifies the size of the individual batches.</param>
    /// <typeparam name="T">Specifies the type of the data in the <paramref name="source"/> sequence.</typeparam>
    /// <returns>A collection of batches created from the specified <paramref name="source"/> sequence.</returns>
    public static IEnumerable<IEnumerable<T>> B<T>(this IEnumerable<T> source, int size = 2) =>
        source.Chunk(size);
}