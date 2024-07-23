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
    ///     Joins the elements of the specified <paramref name="source"/> sequence
    ///     using the specified <paramref name="separator"/>.
    /// </summary>
    /// <typeparam name="T">Specifies the type of data in the sequence.</typeparam>
    /// <param name="source">The source sequence of elements to join together.</param>
    /// <param name="separator">
    ///     The separator that should be placed between each element; the default
    ///     value is <c>, </c>.
    /// </param>
    /// <returns>
    ///     The elements of the specified <paramref name="source"/> sequence
    ///     joined in a <see cref="string"/> using the specified
    ///     <paramref name="separator"/>.
    /// </returns>
    public static string Js<T>(
        this IEnumerable<T> source,
        string separator = ", ") =>
        string.Join(separator, source);
}