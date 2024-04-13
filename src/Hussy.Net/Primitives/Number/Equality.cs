namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<Number>
{
    /// <inheritdoc />
    public bool Equals(Number other) =>
        _value.Equals(other._value);
}