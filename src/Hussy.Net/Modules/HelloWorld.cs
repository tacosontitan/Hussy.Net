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