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
    /// Gets the first element of the source collection.
    /// </summary>
    /// <param name="source">The source collection to get the first element from.</param>
    /// <param name="predicate">A predicate which determines if the element is a match.</param>
    /// <typeparam name="T">Specifies the type of data within the collection.</typeparam>
    /// <returns>
    ///     The first element in the source collection if elements are present;
    ///     otherwise the default value for <typeparamref name="T"/>.
    /// </returns>
    public static T? Fe<T>(
        this IEnumerable<T> source,
        Func<Indexed<T>, bool> predicate)
    {
        var index = 0;
        var sequence = source.ToList();
        foreach (var element in sequence)
        {
            var indexedElement = new Indexed<T>(index, element);
            if (predicate(indexedElement))
                return element;
        }

        return default;
    }
}