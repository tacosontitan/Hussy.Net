namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="Int128"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="Int128"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(Int128 value) =>
        new(value);
}