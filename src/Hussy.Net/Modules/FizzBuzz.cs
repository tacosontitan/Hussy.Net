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
    /// Creates a collection of a specified <paramref name="count"/> of numbers starting from <c>1</c> and prints "FizzBuzz" for multiples of 3 and 5, "Fizz" for
    /// multiples of 3, "Buzz" for multiples of 5, and the numeric value for any other value.
    /// </summary>
    /// <param name="count">The number of values to print.</param>
    public static void Fz(int count) =>
        Fz(start: 1, count);
    
    /// <summary>
    /// Creates a collection of a specified <paramref name="count"/> of numbers from a specified <paramref name="start"/> value and prints <c>FizzBuzz</c> for multiples of <c>3</c> and <c>5</c>, <c>Fizz</c> for multiples of <c>3</c>, <c>Buzz</c> for multiples of <c>5</c>, and the numeric value for any other value.
    /// </summary>
    /// <param name="start">The starting number.</param>
    /// <param name="count">The number of values to print.</param>
    public static void Fz(
        int start,
        int count) => Enumerable.Range(start, count)
        .ToList()
        .ForEach(PrintFizzBuzz);

    private static void PrintFizzBuzz(int input)
    {
        if (input % 3 == 0 && input % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
            return;
        }

        if (input % 3 == 0)
        {
            Console.WriteLine("Fizz");
            return;
        }

        if (input % 5 == 0)
        {
            Console.WriteLine("Buzz");
            return;
        }
        
        Console.WriteLine(input);
    }
}