namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Determines whether the specified value is <see langword="null"/> or not.
    /// </summary>
    /// <param name="value">The value to check for <see langword="null"/>.</param>
    /// <typeparam name="T">Specifies the type of the value being checked.</typeparam>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is not
    ///     <see langword="null"/>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Nnul<T>(T? value)
        where T : class =>
        value is not null;
}