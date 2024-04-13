namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<Int128>
{
    /// <inheritdoc />
    public bool Equals(Int128 other) =>
        _value.Equals(other);
}