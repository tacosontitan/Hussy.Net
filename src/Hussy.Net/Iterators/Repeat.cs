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
    /// Repeats the specified action with the specified input until the specified break condition is met.
    /// </summary>
    /// <param name="action">The action to repeat.</param>
    /// <param name="input">The input to send to the action.</param>
    /// <param name="escapeCondition">The condition for escaping the repeater.</param>
    /// <typeparam name="T">Specifies the type of data the action works with.</typeparam>
    public static void R<T>(
        Action<T> action,
        T input,
        Func<T, bool>? escapeCondition = null)
    {
        while (escapeCondition?.Invoke(input) is not false)
            action(input);
    }
}