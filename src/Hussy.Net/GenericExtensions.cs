namespace Hussy.Net;

/// <summary>
/// Contains extension methods for generic types.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Converts the given value to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the value to.</typeparam>
    /// <param name="source">The value to convert.</param>
    /// <param name="provider">The provider to use when converting.</param>
    /// <returns>The converted value of type <typeparamref name="T"/>.</returns>
    public static T To<T>(this object source, IFormatProvider? provider) =>
        (T)Convert.ChangeType(source, typeof(T), provider);
}