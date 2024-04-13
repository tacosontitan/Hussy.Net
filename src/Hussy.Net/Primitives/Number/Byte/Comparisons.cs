namespace Hussy.Net;

public readonly partial struct Number
    : IComparable<byte>
{
    /// <inheritdoc />
    public int CompareTo(byte other)
    {
        if (_value is not IComparable comparable)
            throw new InvalidOperationException("The value stored in the number is does not implement IComparable.");

        return comparable.CompareTo(other);
    }
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is
    ///     less than the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="Number"/> instance to compare.</param>
    /// <param name="right">The <see cref="byte"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="Number"/> instance
    ///     is less than the specified <see cref="byte"/> instance; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool operator <(
        Number left,
        byte right) =>
        left.CompareTo(right) < 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is
    ///     less than or equal to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="Number"/> instance to compare.</param>
    /// <param name="right">The <see cref="byte"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="Number"/> instance
    ///     is less than or equal to the specified <see cref="byte"/> instance;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator <=(
        Number left,
        byte right) =>
        left.CompareTo(right) <= 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is
    ///     greater than the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="Number"/> instance to compare.</param>
    /// <param name="right">The <see cref="byte"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="Number"/> instance
    ///     is greater than the specified <see cref="byte"/> instance; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool operator >(
        Number left,
        byte right) =>
        left.CompareTo(right) > 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="Number"/> instance is
    ///     greater than or equal to the specified <see cref="byte"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="Number"/> instance to compare.</param>
    /// <param name="right">The <see cref="byte"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="Number"/> instance
    ///     is greater than or equal to the specified <see cref="byte"/> instance;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator >=(
        Number left,
        byte right) =>
        left.CompareTo(right) >= 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="byte"/> instance is
    ///     less than the specified <see cref="Number"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="byte"/> instance to compare.</param>
    /// <param name="right">The <see cref="Number"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="byte"/> instance
    ///     is less than the specified <see cref="Number"/> instance; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool operator <(
        byte left,
        Number right) =>
        left.CompareTo(right) < 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="byte"/> instance is
    ///     less than or equal to the specified <see cref="Number"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="byte"/> instance to compare.</param>
    /// <param name="right">The <see cref="Number"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="byte"/> instance
    ///     is less than or equal to the specified <see cref="Number"/> instance;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator <=(
        byte left,
        Number right) =>
        left.CompareTo(right) <= 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="byte"/> instance is
    ///     greater than the specified <see cref="Number"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="byte"/> instance to compare.</param>
    /// <param name="right">The <see cref="Number"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="byte"/> instance
    ///     is greater than the specified <see cref="Number"/> instance; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool operator >(
        byte left,
        Number right) =>
        left.CompareTo(right) > 0;
    
    /// <summary>
    ///     Determines if the specified <see cref="byte"/> instance is
    ///     greater than or equal to the specified <see cref="Number"/> instance.
    /// </summary>
    /// <param name="left">The <see cref="byte"/> instance to compare.</param>
    /// <param name="right">The <see cref="Number"/> instance to compare.</param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="byte"/> instance
    ///     is greater than or equal to the specified <see cref="Number"/> instance;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator >=(
        byte left,
        Number right) =>
        left.CompareTo(right) >= 0;
}