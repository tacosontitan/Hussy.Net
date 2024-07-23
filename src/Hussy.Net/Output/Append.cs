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

public static partial class Hussy
{
    /// <summary>
    /// Writes the text representation of the specified object to the standard output stream.
    /// </summary>
    /// <param name="value">The value to write.</param>
    public static void A<T>(T value) =>
        Console.Write(value);

    /// <summary>
    ///     Appends the specified <paramref name="primaryValue"/> if it is not
    ///     <see langword="null"/>; otherwise, the specified <paramref name="fallbackValue"/>
    ///     is written.
    /// </summary>
    /// <param name="primaryValue">The primary value to write.</param>
    /// <param name="fallbackValue">
    ///     The value to write if the <paramref name="primaryValue"/> is <see langword="null"/>.
    /// </param>
    /// <typeparam name="TPrimary">Specifies the type of the primary value to write.</typeparam>
    /// <typeparam name="TFallback">Specifies the type of the fallback value to write.</typeparam>
    public static void A<TPrimary, TFallback>(
        TPrimary primaryValue,
        TFallback fallbackValue)
    {
        if (primaryValue is not null)
        {
            Console.Write(primaryValue);
            return;
        }
        
        Console.Write(fallbackValue);
    }
}