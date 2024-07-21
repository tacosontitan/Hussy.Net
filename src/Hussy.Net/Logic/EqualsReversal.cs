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
    ///     Determines if the specified <paramref name="input"/> is
    ///     equal to its reversed <see cref="string"/>.
    /// </summary>
    /// <param name="input">
    ///     The input value to reverse and compare with.
    /// </param>
    /// <typeparam name="T">
    ///     Specifies the type of the <paramref name="input"/>
    ///     to reverse and compare with.
    /// </typeparam>
    /// <returns>
    ///     <see langword="true"/> if the specified <paramref name="input"/>
    ///     is equal to its reversed <see cref="string"/> representation;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    public static bool EqRev<T>(this T input)
    {
        var reversedInput = Rev(input);
        var inputString = input.ToString();
        return inputString == reversedInput;
    }
}