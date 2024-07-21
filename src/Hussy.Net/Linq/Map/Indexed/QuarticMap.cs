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
        Func<
            Indexed<TSource>,
            Indexed<TSource>,
            Indexed<TSource>,
            Indexed<TSource>,
            TResult> mappingFunction)
    {
        var sequence = source.ToList();
        var results = new List<TResult>(capacity: sequence.Count * sequence.Count * sequence.Count);
        for (var x = 0; x < sequence.Count; x++)
        for (var y = 0; y < sequence.Count; y++)
        for (var z = 0; z < sequence.Count; z++)
        for (var w = 0; w < sequence.Count; w++)
        {
            var indexedX = new Indexed<TSource>(x, sequence[x]);
            var indexedY = new Indexed<TSource>(y, sequence[y]);
            var indexedZ = new Indexed<TSource>(z, sequence[z]);
            var indexedW = new Indexed<TSource>(w, sequence[w]);
            var result = mappingFunction(indexedX, indexedY, indexedZ, indexedW);
            results.Add(result);
        }

        return results;
    }
}