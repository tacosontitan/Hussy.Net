namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Creates a classic array string (e.g. <c>[1, 2, 3]</c>) for the specified sequence.
    /// </summary>
    /// <param name="sequence">The sequence to create the array string for.</param>
    /// <param name="separator">The separator to use between elements (defaults to <c>, </c>).</param>
    /// <typeparam name="T">Specifies the type of data in the sequence.</typeparam>
    /// <returns>The input sequence wrapped in square brackets and separated by commas and spaces.</returns>
    /// <example>
    /// Behind the scenes, this method simply interpolates a call to <c>string.Join</c> with <c>", "</c> as the
    /// separator. This results in an output string of <c>[1, 2, 3, ...]</c>, to use it, simply specify a collection
    /// parameter:
    ///
    /// <code>
    /// // Generate a range to work with:
    /// var sequence = Gr(5);
    ///
    /// // Create the formatted string:
    /// var output = Far(sequence);
    ///
    /// // Append the output to the output stream:
    /// A(output);
    /// </code>
    ///
    /// The expected output of the above snippet is:
    ///
    /// > [1, 2, 3, 4, 5]
    /// </example>
    public static string Fsq<T>(
        IEnumerable<T>? sequence,
        string separator = ", ") =>
        $"[{string.Join(separator, sequence ?? [])}]";
}