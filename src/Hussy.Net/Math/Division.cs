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

using System.Numerics;

namespace Hussy.Net;

public static partial class Hussy
{
    /// <summary>
    /// Divides the specified by input by <c>2</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>2</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div2<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 2.To<T>();

    /// <summary>
    /// Divides the specified by input by <c>3</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>3</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div3<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 3.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>4</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>4</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div4<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 4.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>5</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>2</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div5<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 5.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>6</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>6</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div6<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 6.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>7</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>7</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div7<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 7.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>8</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>8</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div8<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 8.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>9</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>9</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div9<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 9.To<T>();
    
    /// <summary>
    /// Divides the specified by input by <c>10</c>.
    /// </summary>
    /// <param name="input">The input to divide.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> divided by <c>10</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Div10<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 10.To<T>();
}