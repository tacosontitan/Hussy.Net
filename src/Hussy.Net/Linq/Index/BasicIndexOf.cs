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
    /// Gets the index of the specified element within the source collection.
    /// </summary>
    /// <param name="source">The source collection to look through.</param>
    /// <param name="element">The element to look for.</param>
    /// <typeparam name="T">Specifies the type of data within the source collection.</typeparam>
    /// <returns>
    ///     The index of the element within the collection if found;
    ///     otherwise <c>-1</c>.
    /// </returns>
    public static int I<T>(
        this IEnumerable<T> source,
        T element)
    {
        var sequence = source.ToList();
        for (var index = 0; index < sequence.Count; index++)
        {
            var elementAtIndex = sequence[index];
            if (element.Equals(elementAtIndex))
                return index;
        }

        return -1;
    }
}