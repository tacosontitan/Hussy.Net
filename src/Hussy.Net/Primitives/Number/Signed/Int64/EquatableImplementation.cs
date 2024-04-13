namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<long>
{
    /// <inheritdoc />
    public bool Equals(long other) =>
        _value.Equals(other);
}