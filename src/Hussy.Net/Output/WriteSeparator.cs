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
    /// Writes a separator line of specified character and length to the console.
    /// </summary>
    /// <param name="character">The character used for the separator line. Default is '='.</param>
    /// <param name="length">The length of the separator line. Default is 25.</param>
    public static void Ws(
        char character = '=',
        int length = 25)
    {
        var separator = new string(character, length);
        Console.WriteLine(separator);
    }
}