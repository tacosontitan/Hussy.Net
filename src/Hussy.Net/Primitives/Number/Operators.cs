namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Determines if two <see cref="Number"/> instances are equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are equal;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(
        Number left,
        Number right) =>
        left.Equals(right);
    
    /// <summary>
    /// Determines if two <see cref="Number"/> instances are <b>not</b> equal.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are <b>not</b>
    ///     equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(
        Number left,
        Number right) =>
        left.Equals(right);
}