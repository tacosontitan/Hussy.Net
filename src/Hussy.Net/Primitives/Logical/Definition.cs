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
{
    private readonly bool _value;

    private L(bool value) =>
        _value = value;
    
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

    public static bool operator ==(L left, L right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(L left, L right)
    {
        return !(left == right);
    }
}