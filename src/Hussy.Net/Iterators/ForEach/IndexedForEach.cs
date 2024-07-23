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
    /// Applies the specified action to each element in the source collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source collection.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="action">The action to be applied to each element.</param>
    /// <returns>The source collection.</returns>
    public static IEnumerable<T> Ei<T>(
        this IEnumerable<T> source,
        Action<int, T> action)
    {
        var index = 0;
        var elements = source.ToList();
        foreach (var element in elements)
            action(index++, element);

        return elements;
    }
}