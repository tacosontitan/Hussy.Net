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

using Glitter;

namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Writes <c>Hello, world!</c> to the console.
    /// </summary>
    /// <param name="variant">The documented index for the variant to print.</param>
    public static void Yo(int variant = 0)
    {
        variant.Clamp(lowerBound: 0, upperBound: _variants.Length - 1);
        
        string output = _variants[variant];
        Console.Write(output);
    }
    
    private static string[] _variants =
    [
        "Hello, world!",
        "hello, world!"
    ];
}