namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Determines whether the given number is odd.
    /// </summary>
    /// <param name="source">The number to check.</param>
    /// <returns>True if the number is odd; otherwise, false.</returns>
    public static bool OD(int source) =>
        source % 2 == 1;
}