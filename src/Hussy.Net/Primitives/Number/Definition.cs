namespace Hussy.Net;

/// <summary>
/// Represents a numeric value.
/// </summary>
public readonly partial struct Number
{
    private readonly dynamic _value;

    private Number(dynamic value) =>
        _value = value;
}