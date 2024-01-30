namespace Hussy.Net.Primitives;

/// <summary>
/// Represents a logical value such as <see langword="true"/> or <see langword="false"/>.
/// </summary>
public struct L
    : IComparable, 
      IComparable<L>, 
      IConvertible, 
      IEquatable<L>, 
      ISpanParsable<L>
{
    private readonly bool _value;

    private L(bool value) =>
        _value = value;
    
    /// <inhreitdoc />
    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }

    /// <inhreitdoc />
    public int CompareTo(L other) =>
        _value.CompareTo(other._value);

    /// <inhreitdoc />
    public TypeCode GetTypeCode() =>
        TypeCode.Boolean;

    /// <inhreitdoc />
    public bool ToBoolean(IFormatProvider? provider) => _value;

    /// <inhreitdoc />
    public byte ToByte(IFormatProvider? provider) =>
        _value.To<byte>(provider);

    public char ToChar(IFormatProvider? provider) =>
        _value.To<char>(provider);

    /// <inhreitdoc />
    public DateTime ToDateTime(IFormatProvider? provider) =>
        _value.To<DateTime>(provider);

    /// <inhreitdoc />
    public decimal ToDecimal(IFormatProvider? provider) =>
        _value.To<decimal>(provider);

    /// <inhreitdoc />
    public double ToDouble(IFormatProvider? provider) =>
        _value.To<double>(provider);
    
    /// <inhreitdoc />
    public short ToInt16(IFormatProvider? provider) =>
        _value.To<short>(provider);

    /// <inhreitdoc />
    public int ToInt32(IFormatProvider? provider) =>
        _value.To<int>(provider);

    /// <inhreitdoc />
    public long ToInt64(IFormatProvider? provider) =>
        _value.To<long>(provider);

    /// <inhreitdoc />
    public sbyte ToSByte(IFormatProvider? provider) =>
        _value.To<sbyte>(provider);

    /// <inhreitdoc />
    public float ToSingle(IFormatProvider? provider) =>
        _value.To<float>(provider);

    /// <inhreitdoc />
    public string ToString(IFormatProvider? provider) =>
        _value.ToString(provider);

    /// <inhreitdoc />
    public object ToType(Type conversionType, IFormatProvider? provider) =>
        Convert.ChangeType(_value, conversionType, provider);

    /// <inhreitdoc />
    public ushort ToUInt16(IFormatProvider? provider) =>
        _value.To<ushort>(provider);

    /// <inhreitdoc />
    public uint ToUInt32(IFormatProvider? provider) =>
        _value.To<uint>(provider);

    /// <inhreitdoc />
    public ulong ToUInt64(IFormatProvider? provider) =>
        _value.To<ulong>(provider);

    /// <inhreitdoc />
    public bool Equals(L other) =>
        _value.Equals(other._value);

    /// <inhreitdoc />
    public static L Parse(string s, IFormatProvider? provider)
    {
        if (bool.TryParse(s, out bool value))
            return new L(value);
        
        if (double.TryParse(s, out double numericValue))
            return new L(numericValue >= 1);
        
        throw new FormatException();
    }

    /// <inhreitdoc />
    public static bool TryParse(string? s, IFormatProvider? provider, out L result)
    {
        if (bool.TryParse(s, out bool value))
        {
            result = new L(value);
            return true;
        }
        
        if (double.TryParse(s, out double numericValue))
        {
            result = new L(numericValue >= 1);
            return true;
        }
        
        result = default;
        return false;
    }

    /// <inhreitdoc />
    public static L Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        if (bool.TryParse(s, out bool value))
            return new L(value);
        
        if (double.TryParse(s, out double numericValue))
            return new L(numericValue >= 1);
        
        throw new FormatException();
    }

    /// <inhreitdoc />
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out L result)
    {
        if (bool.TryParse(s, out bool value))
        {
            result = new L(value);
            return true;
        }
        
        if (double.TryParse(s, out double numericValue))
        {
            result = new L(numericValue >= 1);
            return true;
        }
        
        result = default;
        return false;
    }
    
    public static implicit operator L(bool value) =>
        new(value);
    
    public static implicit operator bool(L value) =>
        value._value;
    
    public static implicit operator L(int value) =>
        new(value >= 1);
    
    public static implicit operator L(double value) =>
        new(value >= 1);
    
    public static implicit operator L(decimal value) =>
        new(value >= 1);
    
    public static implicit operator L(string value) =>
        Parse(value, provider: null);
}