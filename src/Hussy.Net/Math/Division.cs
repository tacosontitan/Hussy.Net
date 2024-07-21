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
    public static T Dv2<T>(T input)
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
    public static T Dv3<T>(T input)
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
    public static T Dv4<T>(T input)
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
    public static T Dv5<T>(T input)
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
    public static T Dv6<T>(T input)
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
    public static T Dv7<T>(T input)
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
    public static T Dv8<T>(T input)
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
    public static T Dv9<T>(T input)
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
    public static T Dv10<T>(T input)
        where T : IDivisionOperators<T, T, T> =>
        input / 10.To<T>();
}