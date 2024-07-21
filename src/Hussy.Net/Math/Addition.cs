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
    /// Adds <c>1</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>1</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>1</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad1<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 1.To<T>();
    
    /// <summary>
    /// Adds <c>2</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>2</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>2</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad2<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 2.To<T>();
    
    /// <summary>
    /// Adds <c>3</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>3</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>3</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad3<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 3.To<T>();
    
    /// <summary>
    /// Adds <c>4</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>4</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>4</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad4<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 4.To<T>();
    
    /// <summary>
    /// Adds <c>5</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>5</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>5</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad5<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 5.To<T>();
    
    /// <summary>
    /// Adds <c>6</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>6</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>6</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad6<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 6.To<T>();
    
    /// <summary>
    /// Adds <c>7</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>7</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>7</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad7<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 7.To<T>();
    
    /// <summary>
    /// Adds <c>8</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>1</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>8</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad8<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 8.To<T>();
    
    /// <summary>
    /// Adds <c>9</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>9</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>9</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad9<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 9.To<T>();
    
    /// <summary>
    /// Adds <c>10</c> to the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to add <c>10</c> to.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> incremented by <c>10</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Ad10<T>(T input)
        where T : IAdditionOperators<T, T, T> =>
        input + 10.To<T>();
}