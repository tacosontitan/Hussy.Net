﻿/*
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
    ///     Converts the specified <paramref name="input"/>
    ///     to a <see cref="string"/> and reverses it.
    /// </summary>
    /// <param name="input">
    ///     The <paramref name="input"/> to reverse.
    /// </param>
    /// <typeparam name="T">
    ///     Specifies the type of the <paramref name="input"/> to reverse.
    /// </typeparam>
    /// <returns>
    ///     The reversal of the specified <paramref name="input"/>.
    /// </returns>
    public static string Rev<T>(T input)
    {
        var stringValue = input?.ToString();
        if (stringValue is null)
            throw new ArgumentNullException(nameof(input), message: "Unable to reverse a null input.");

        var reversedSequence = stringValue.Reverse().ToArray();
        return new string(reversedSequence);
    }
}