namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="double"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="double"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(double value) =>
        new(value);
}