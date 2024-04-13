namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<byte>
{
    /// <inheritdoc />
    public bool Equals(byte other) =>
        _value.Equals(other);
}