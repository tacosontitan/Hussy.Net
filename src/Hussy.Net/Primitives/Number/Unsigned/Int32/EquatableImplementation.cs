namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<uint>
{
    /// <inheritdoc />
    public bool Equals(uint other) =>
        _value.Equals(other);
}