namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    /// <summary>
    /// Represents a very mundane approach to the problem to understand where Hussy can be improved.
    /// </summary>
    /// <param name="target">The stopping value for the test.</param>
    /// <returns>
    ///     A collection of strings representing the output for the specified <paramref name="target"/>.
    /// </returns>
    private static IEnumerable<string> DryRun(int target)
    {
        for (int i = 1; i <= target; i++)
        {
            string element = null;
            for (int j = i; j % 3 == 0; j /= 3)
                element += "Fizz";

            for (int j = i; j % 5 == 0; j /= 5)
                element += "Buzz";

            if (i % 3 != 0 && i % 5 != 0)
                element = i.ToString();

            yield return element;
        }
    }
}