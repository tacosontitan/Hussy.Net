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
    /// Prompts the user with a message and reads the user's response, parsing it into the specified type.
    /// </summary>
    /// <typeparam name="T">The type to parse the user's response into.</typeparam>
    /// <param name="message">The message to display to the user.</param>
    /// <param name="formatProvider">The format provider to use for parsing the response. If null, the default format provider is used.</param>
    /// <returns>The parsed user's response of type T.</returns>
    public static T P<T>(
        string message,
        IFormatProvider? formatProvider = null)
        where T : IParsable<T>
    {
        Console.Write(message);
        var response = Console.ReadLine();
        if (!T.TryParse(response, formatProvider, out var parsedResponse))
            throw new FormatException("Unable to parse response.");

        return parsedResponse;
    }
}