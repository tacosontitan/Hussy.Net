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
    /// Determines whether the specified value is divisible by all the specified operands.
    /// </summary>
    /// <param name="value">The value to check for divisibility.</param>
    /// <param name="operands">The operands to check for divisibility against the value.</param>
    /// <returns>
    /// <c>true</c> if the value is divisible by all the operands; otherwise, <c>false</c>.
    /// </returns>
    public static bool Dvb(
        this int value,
        params int[] operands)
    {
        foreach (int operand in operands)
            if (value % operand != 0)
                return false;

        return true;
    }

    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>1</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>1</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb1(int value) =>
        value % 1 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>2</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>2</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb2(int value) =>
        value % 2 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>3</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>3</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb3(int value) =>
        value % 3 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>4</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>4</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb4(int value) =>
        value % 4 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>5</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>5</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb5(int value) =>
        value % 5 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>6</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>6</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb6(int value) =>
        value % 6 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>7</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>7</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb7(int value) =>
        value % 7 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>8</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>8</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb8(int value) =>
        value % 8 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>9</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>9</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb9(int value) =>
        value % 9 == 0;
    
    /// <summary>
    /// Determines whether the specified value is evenly divisible by <c>10</c>.
    /// </summary>
    /// <param name="value">The value to check for visibility.</param>
    /// <returns>
    ///     <see langword="true"/> if <paramref name="value"/> is
    ///     evenly divisible by <c>10</c>; otherwise,
    ///     <see langword="false"/>.
    /// </returns>
    public static bool Dvb10(int value) =>
        value % 10 == 0;
}