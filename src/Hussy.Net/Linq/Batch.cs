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
    /// Batches the specified <paramref name="source"/> sequence into chunks of the specified <paramref name="size"/>.
    /// </summary>
    /// <param name="source">Specifies the source sequence to batch.</param>
    /// <param name="size">Specifies the size of the individual batches.</param>
    /// <typeparam name="T">Specifies the type of the data in the <paramref name="source"/> sequence.</typeparam>
    /// <returns>A collection of batches created from the specified <paramref name="source"/> sequence.</returns>
    public static IEnumerable<IEnumerable<T>> B<T>(
        this IEnumerable<T> source,
        int size = 2) =>
        source.Chunk(size);
}