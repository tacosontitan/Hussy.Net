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
    /// Determines whether the specified value is <see langword="null"/> or not.
    /// </summary>
    /// <param name="value">The value to check for <see langword="null"/>.</param>
    /// <typeparam name="T">Specifies the type of the value being checked.</typeparam>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is not
    ///     <see langword="null"/>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Nnul<T>(T? value)
        where T : class =>
        value is not null;
}