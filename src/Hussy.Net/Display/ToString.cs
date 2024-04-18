namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Converts the specified input to its <see cref="string"/> representation.
    /// </summary>
    /// <param name="input">The input to convert.</param>
    /// <typeparam name="T">Specifies the type of the <paramref name="input"/> to convert.</typeparam>
    /// <returns>
    ///     The <see cref="string"/> representation of the specified
    ///     <paramref name="input"/> instance.
    /// </returns>
    public static string Ts<T>(this T input) =>
        input.ToString();
}