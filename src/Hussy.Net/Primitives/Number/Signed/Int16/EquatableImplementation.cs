namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<short>
{
    /// <inheritdoc />
    public bool Equals(short other) =>
        _value.Equals(other);
}