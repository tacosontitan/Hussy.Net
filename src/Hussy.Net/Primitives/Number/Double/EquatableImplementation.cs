namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<double>
{
    /// <inheritdoc />
    public bool Equals(double other) =>
        _value.Equals(other);
}