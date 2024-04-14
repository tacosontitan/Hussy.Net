namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    ///     Determines if the specified <paramref name="input"/> is
    ///     equal to its reversed <see cref="string"/>.
    /// </summary>
    /// <param name="input">
    ///     The input value to reverse and compare with.
    /// </param>
    /// <typeparam name="T">
    ///     Specifies the type of the <paramref name="input"/>
    ///     to reverse and compare with.
    /// </typeparam>
    /// <returns>
    ///     <see langword="true"/> if the specified <paramref name="input"/>
    ///     is equal to its reversed <see cref="string"/> representation;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool EqRev<T>(this T input)
    {
        var reversedInput = Rev(input);
        var inputString = input.ToString();
        return inputString == reversedInput;
    }
}