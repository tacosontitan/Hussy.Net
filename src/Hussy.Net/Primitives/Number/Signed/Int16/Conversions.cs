namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="short"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="short"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(short value) =>
        new(value);
}