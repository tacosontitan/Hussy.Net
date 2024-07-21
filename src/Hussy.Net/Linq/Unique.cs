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
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Gets the unique elements in the collection.
    /// </summary>
    /// <param name="source">The collection to get unique elements from.</param>
    /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
    /// <returns>The unique elements in the collection.</returns>
    public static IEnumerable<T> U<T>(this IEnumerable<T> source) =>
        source.Distinct();
    
    /// <summary>
    /// Gets the unique or empty version of the source collection.
    /// </summary>
    /// <param name="source">The input sequence to use.</param>
    /// <typeparam name="T">Specifies the type of data in the collection.</typeparam>
    /// <returns>The source collection if all elements are unique, otherwise an empty collection.</returns>
    public static IEnumerable<T> Uoe<T>(this IEnumerable<T> source) =>
        source.Distinct().Count() < source.Count()
            ? Enumerable.Empty<T>() 
            : source;
}