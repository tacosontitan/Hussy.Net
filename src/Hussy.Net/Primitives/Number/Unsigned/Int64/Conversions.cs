namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="ulong"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="ulong"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(ulong value) =>
        new(value);
}