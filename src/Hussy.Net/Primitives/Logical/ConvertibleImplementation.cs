/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace Hussy.Net;

/// <summary>
/// Represents a logical value such as <see langword="true"/> or <see langword="false"/>.
/// </summary>
public readonly partial struct L
    : IConvertible
{
    /// <inheritdoc />
    public TypeCode GetTypeCode() =>
        TypeCode.Boolean;

    /// <inheritdoc />
    public bool ToBoolean(IFormatProvider? provider) => _value;

    /// <inheritdoc />
    public byte ToByte(IFormatProvider? provider) =>
        _value.To<byte>(provider);

    public char ToChar(IFormatProvider? provider) =>
        _value.To<char>(provider);

    /// <inheritdoc />
    public DateTime ToDateTime(IFormatProvider? provider) =>
        _value.To<DateTime>(provider);

    /// <inheritdoc />
    public decimal ToDecimal(IFormatProvider? provider) =>
        _value.To<decimal>(provider);

    /// <inheritdoc />
    public double ToDouble(IFormatProvider? provider) =>
        _value.To<double>(provider);
    
    /// <inheritdoc />
    public short ToInt16(IFormatProvider? provider) =>
        _value.To<short>(provider);

    /// <inheritdoc />
    public int ToInt32(IFormatProvider? provider) =>
        _value.To<int>(provider);

    /// <inheritdoc />
    public long ToInt64(IFormatProvider? provider) =>
        _value.To<long>(provider);

    /// <inheritdoc />
    public sbyte ToSByte(IFormatProvider? provider) =>
        _value.To<sbyte>(provider);

    /// <inheritdoc />
    public float ToSingle(IFormatProvider? provider) =>
        _value.To<float>(provider);

    /// <inheritdoc />
    public string ToString(IFormatProvider? provider) =>
        _value.ToString(provider);

    /// <inheritdoc />
    public object ToType(Type conversionType, IFormatProvider? provider) =>
        Convert.ChangeType(_value, conversionType, provider);

    /// <inheritdoc />
    public ushort ToUInt16(IFormatProvider? provider) =>
        _value.To<ushort>(provider);

    /// <inheritdoc />
    public uint ToUInt32(IFormatProvider? provider) =>
        _value.To<uint>(provider);

    /// <inheritdoc />
    public ulong ToUInt64(IFormatProvider? provider) =>
        _value.To<ulong>(provider);
}