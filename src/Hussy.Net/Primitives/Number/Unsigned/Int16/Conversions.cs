namespace Hussy.Net;

public readonly partial struct Number
{
    /// <summary>
    /// Implicitly converts from a <see cref="ushort"/> to a <see cref="Number"/>.
    /// </summary>
    /// <param name="value">The <see cref="ushort"/> value to convert.</param>
    /// <returns>The converted <see cref="Number"/> instance.</returns>
    public static implicit operator Number(ushort value) =>
        new(value);
}