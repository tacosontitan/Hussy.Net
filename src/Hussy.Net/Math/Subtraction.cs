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
    /// Subtracts <c>1</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>1</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>1</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub1<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 1.To<T>();
    
    /// <summary>
    /// Subtracts <c>2</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>2</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>2</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub2<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 2.To<T>();
    
    /// <summary>
    /// Subtracts <c>3</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>3</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>3</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub3<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 3.To<T>();
    
    /// <summary>
    /// Subtracts <c>4</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>4</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>4</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub4<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 4.To<T>();
    
    /// <summary>
    /// Subtracts <c>5</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>5</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>5</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub5<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 5.To<T>();
    
    /// <summary>
    /// Subtracts <c>6</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>6</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>6</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub6<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 6.To<T>();
    
    /// <summary>
    /// Subtracts <c>7</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>7</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>7</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub7<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 7.To<T>();
    
    /// <summary>
    /// Subtracts <c>8</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>1</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>8</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub8<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 8.To<T>();
    
    /// <summary>
    /// Subtracts <c>9</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>9</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>9</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub9<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 9.To<T>();
    
    /// <summary>
    /// Subtracts <c>10</c> from the specified <paramref name="input"/>.
    /// </summary>
    /// <param name="input">The input to subtract <c>10</c> from.</param>
    /// <typeparam name="T">Specifies the type of <paramref name="input"/>.</typeparam>
    /// <returns>
    ///     The specified <paramref name="input"/> decremented by <c>10</c>.
    /// </returns>
    /// <remarks>This method is designed to shorten functions being passed as delegates.</remarks>
    public static T Sub10<T>(T input)
        where T : ISubtractionOperators<T, T, T> =>
        input - 10.To<T>();
}