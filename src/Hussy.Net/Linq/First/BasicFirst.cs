namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Gets the first element of the source collection.
    /// </summary>
    /// <param name="source">The source collection to get the first element from.</param>
    /// <typeparam name="T">Specifies the type of data within the collection.</typeparam>
    /// <returns>
    ///     The first element in the source collection if elements are present;
    ///     otherwise the default value for <typeparamref name="T"/>.
    /// </returns>
    public static T? Fe<T>(this IEnumerable<T> source) =>
        source.FirstOrDefault();
}