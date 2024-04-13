namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<ushort>
{
    /// <inheritdoc />
    public bool Equals(ushort other) =>
        _value.Equals(other);
}