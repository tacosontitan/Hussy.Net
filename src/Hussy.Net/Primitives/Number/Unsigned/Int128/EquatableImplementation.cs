namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<UInt128>
{
    /// <inheritdoc />
    public bool Equals(UInt128 other) =>
        _value.Equals(other);
}