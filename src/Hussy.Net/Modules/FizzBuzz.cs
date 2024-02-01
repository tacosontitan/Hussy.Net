namespace Hussy.Net;

/// <summary>
/// Defines static methods for common programming tasks.
/// </summary>
public static partial class Hussy
{
    /// <summary>
    /// Creates a collection of a specified <paramref name="count"/> of numbers starting from <c>1</c> and prints "FizzBuzz" for multiples of 3 and 5, "Fizz" for
    /// multiples of 3, "Buzz" for multiples of 5, and the numeric value for any other value.
    /// </summary>
    /// <param name="count">The number of values to print.</param>
    public static void FZ(int count) =>
        FZ(start: 1, count);
    
    /// <summary>
    /// Creates a collection of a specified <paramref name="count"/> of numbers from a specified <paramref name="start"/> value and prints <c>FizzBuzz</c> for multiples of <c>3</c> and <c>5</c>, <c>Fizz</c> for multiples of <c>3</c>, <c>Buzz</c> for multiples of <c>5</c>, and the numeric value for any other value.
    /// </summary>
    /// <param name="start">The starting number.</param>
    /// <param name="count">The number of values to print.</param>
    public static void FZ(int start, int count) => Enumerable.Range(start, count)
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