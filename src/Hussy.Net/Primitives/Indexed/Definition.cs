namespace Hussy.Net;

/// <summary>
/// Defines an indexed value for simplifying working with collections.
/// </summary>
/// <typeparam name="T">Specifies the type of the value being indexed.</typeparam>
public partial class Indexed<T>(
    int index,
    T value)
{
    /// <summary>
    /// Gets or sets the index of this element.
    /// </summary>
    public int Index { get; set; } = index;

    /// <summary>
    /// Gets or sets the value of this indexed element.
    /// </summary>
    public T Value { get; set; } = value;
}