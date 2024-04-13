namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<int>
{
    /// <inheritdoc />
    public bool Equals(int other) =>
        _value.Equals(other);
}