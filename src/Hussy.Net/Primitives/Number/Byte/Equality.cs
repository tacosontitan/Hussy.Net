namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<byte>
{
    /// <inheritdoc />
    public bool Equals(byte other) =>
        _value.Equals(other);
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is equal
    ///     to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are equal;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(
        Number left,
        byte right) =>
        left.Equals(right);
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is equal
    ///     to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are <b>not</b>
    ///     equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(
        Number left,
        byte right) =>
        left.Equals(right);

    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is equal
    ///     to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are equal;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(
        byte left,
        Number right) =>
        right.Equals(left);

    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is equal
    ///     to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The first instance to compare.</param>
    /// <param name="right">The second instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the two instances are <b>not</b>
    ///     equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(
        byte left,
        Number right) =>
        right.Equals(left);
}