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
    /// Generates a range of values starting with <c>1</c> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <returns>A range of values starting with <c>1</c> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<int> R(int count) =>
        Enumerable.Range(1, count);

    /// <summary>
    /// Generates a range of values from the specified <paramref name="start"/> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="start">The starting value for the range.</param>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <returns>A range of values starting with <paramref name="start"/> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<int> R(int start, int count) =>
        Enumerable.Range(start, count);

    /// <summary>
    /// Generates a range of values from the specified <paramref name="start"/> through the specified <paramref name="count"/> value.
    /// </summary>
    /// <param name="start">The starting value for the range.</param>
    /// <param name="count">The maximum value to include in the range.</param>
    /// <param name="stepSize">The step value to use when generating the range.</param>
    /// <returns>A range of values starting with <paramref name="start"/> through the specified <paramref name="count"/> value.</returns>
    public static IEnumerable<int> R(int start, int count, int stepSize)
    {
        List<int> range = new(capacity: count);
        for (int i = 0; i < count; i++)
        {
            range.Add(start);
            start += stepSize;
        }
        
        return range;
    }
}