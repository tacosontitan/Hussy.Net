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
    /// Creates a classic array string (e.g. <c>[1, 2, 3]</c>) for the specified sequence.
    /// </summary>
    /// <param name="sequence">The sequence to create the array string for.</param>
    /// <param name="separator">The separator to use between elements (defaults to <c>, </c>).</param>
    /// <typeparam name="T">Specifies the type of data in the sequence.</typeparam>
    /// <returns>The input sequence wrapped in square brackets and separated by commas and spaces.</returns>
    /// <example>
    /// Behind the scenes, this method simply interpolates a call to <c>string.Join</c> with <c>", "</c> as the
    /// separator. This results in an output string of <c>[1, 2, 3, ...]</c>, to use it, simply specify a collection
    /// parameter:
    ///
    /// <code>
    /// // Generate a range to work with:
    /// var sequence = Gr(5);
    ///
    /// // Create the formatted string:
    /// var output = Fsq(sequence);
    ///
    /// // Append the output to the output stream:
    /// A(output);
    /// </code>
    ///
    /// The expected output of the above snippet is:
    ///
    /// > [1, 2, 3, 4, 5]
    /// </example>
    public static string Fsq<T>(
        IEnumerable<T>? sequence,
        string separator = ", ") =>
        $"[{string.Join(separator, sequence ?? [])}]";
}