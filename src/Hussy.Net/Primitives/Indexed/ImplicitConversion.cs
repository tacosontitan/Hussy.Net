namespace Hussy.Net;

public partial class Indexed<T>
{
    /// <summary>
    /// Implicitly converts an indexed value to its value component.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The value of the indexed value.</returns>
    public static implicit operator T(Indexed<T> value) =>
        value.V;

    /// <summary>
    /// Implicitly converts an indexed value to its index component.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The index of the indexed value.</returns>
    public static implicit operator int(Indexed<T> value) =>
        value.I;
}