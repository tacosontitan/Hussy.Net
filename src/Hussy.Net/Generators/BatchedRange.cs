namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Generates a range of values starting with <c>1</c> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <returns>A range of values starting with <c>1</c> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<IEnumerable<int>> Gbr(int count, int batchSize) =>
        Enumerable.Range(1, count).Chunk(batchSize);

    /// <summary>
    /// Generates a range of values from the specified <paramref name="start"/> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="start">The starting value for the range.</param>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <returns>A range of values starting with <paramref name="start"/> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<IEnumerable<int>> Gbr(int start, int count, int batchSize) =>
        Enumerable.Range(start, count).Chunk(batchSize);

    /// <summary>
    /// Generates a range of values from the specified <paramref name="start"/> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="start">The starting value for the range.</param>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <param name="stepSize">The step value to use when generating the range.</param>
    /// <returns>A range of values starting with <paramref name="start"/> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<IEnumerable<int>> Gbr(int start, int count, int stepSize, int batchSize)
    {
        List<int> range = new(capacity: count);
        for (int i = 0; i < count; i++)
        {
            range.Add(start);
            start += stepSize;
        }
        
        return range.Chunk(batchSize);
    }
}