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
    ///     <paramref name="input"/> instance. A value of
    ///     <see langword="null"/> will return a <see cref="string"/>
    ///     containing the word <see langword="null"/>.
    /// </returns>
    public static string Ts<T>(this T input)
    {
        var result = input?.ToString();
        return result ?? "null";
    }
}