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
/// Contains extension methods for generic types.
/// </summary>
public static class GenericExtensions
{
    /// <summary>
    /// Converts the given value to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to convert the value to.</typeparam>
    /// <param name="source">The value to convert.</param>
    /// <param name="provider">The provider to use when converting.</param>
    /// <returns>The converted value of type <typeparamref name="T"/>.</returns>
    public static T To<T>(
        this object source,
        IFormatProvider? provider = null) =>
        (T)Convert.ChangeType(source, typeof(T), provider);
}