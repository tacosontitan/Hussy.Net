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
    /// Imitates a <see langword="for"/> loop.
    /// </summary>
    /// <param name="startingValue">The value to start iterating with.</param>
    /// <param name="iterationCondition">The condition for each iteration to execute.</param>
    /// <param name="iterator">The mutation that should be applied to the iterator value.</param>
    /// <param name="action">The action to invoke with every iteration.</param>
    /// <typeparam name="T">Specifies the type of data the iterator works with.</typeparam>
    public static void F<T>(
        T startingValue,
        Func<T, bool> iterationCondition,
        Func<T, T> iterator,
        Action<T> action)
    {
        var currentValue = startingValue;
        while (iterationCondition(currentValue))
        {
            action(currentValue);
            currentValue = iterator(currentValue);
        }
    }
}