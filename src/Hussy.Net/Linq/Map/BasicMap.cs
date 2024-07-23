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
    /// Applies a mapping function to each element in the source enumerable and returns an enumerable
    /// containing the result of the mapping.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source enumerable.</typeparam>
    /// <typeparam name="TResult">The type of the elements in the resulting enumerable.</typeparam>
    /// <param name="source">The source enumerable.</param>
    /// <param name="mappingFunction">The mapping function to apply to each element.</param>
    /// <returns>An enumerable containing the results of the mapping.</returns>
    public static IEnumerable<TResult> M<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TResult> mappingFunction) =>
        source.Select(mappingFunction);
}