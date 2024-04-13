namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<float>
{
    /// <inheritdoc />
    public bool Equals(float other) =>
        _value.Equals(other);
}