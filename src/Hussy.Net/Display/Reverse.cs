namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    ///     Converts the specified <paramref name="input"/>
    ///     to a <see cref="string"/> and reverses it.
    /// </summary>
    /// <param name="input">
    ///     The <paramref name="input"/> to reverse.
    /// </param>
    /// <typeparam name="T">
    ///     Specifies the type of the <paramref name="input"/> to reverse.
    /// </typeparam>
    /// <returns>
    ///     The reversal of the specified <paramref name="input"/>.
    /// </returns>
    public static string Rev<T>(T input)
    {
        var stringValue = input.ToString();
        var reversedSequence = stringValue.Reverse().ToArray();
        return new string(reversedSequence);
    }
}