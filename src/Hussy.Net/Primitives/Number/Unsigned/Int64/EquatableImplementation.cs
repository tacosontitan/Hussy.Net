namespace Hussy.Net;

public readonly partial struct Number
    : IEquatable<ulong>
{
    /// <inheritdoc />
    public bool Equals(ulong other) =>
        _value.Equals(other);
}