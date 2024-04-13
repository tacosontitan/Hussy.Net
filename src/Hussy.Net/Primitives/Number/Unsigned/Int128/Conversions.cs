namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="UInt128"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="UInt128"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(UInt128 value) =>
        new(value);
}