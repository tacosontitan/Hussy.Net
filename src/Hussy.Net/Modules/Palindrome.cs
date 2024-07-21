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
    /// Determines if an integer <paramref name="input"/> is a palindrome.
    /// </summary>
    /// <param name="input">The <see cref="int"/> instance to evaluate.</param>
    /// <returns>
    ///     <see langword="true"/> if the number is a palindrome;
    ///     otherwise, <see langword="false"/>.
    /// </returns>
    /// <see href="https://en.wikipedia.org/wiki/Palindrome"/>
    public static bool Pal(int input)
    {
        if (input < 0)
            return false;

        var reversal = 0;
        var testValue = input;
        while (testValue > 0)
        {
            var lastDigit = testValue % 10;
            reversal = reversal * 10 + lastDigit;
            testValue /= 10;
        }

        return reversal == input;
    }
}