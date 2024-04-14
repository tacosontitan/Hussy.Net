namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    /// <summary>
    /// The golfed run simply compresses the dry run.
    /// </summary>
    /// <param name="target">The stopping value for the test.</param>
    /// <returns>
    ///     A collection of strings representing the output for the specified <paramref name="target"/>.
    /// </returns>
    /// <remarks>
    ///     Fully condensed, this method body becomes <c>156</c> bytes.
    /// </remarks>
    private static IEnumerable<string> GolfedDryRun(int t)
    {
        for (int i = 1; i <= t; i++)
        {
            int f = i, b = i;
            string element = null;
            for (; f % 3 == 0; f /= 3)
                element += "Fizz";

            for (; b % 5 == 0; b /= 5)
                element += "Buzz";

            if (i % 3 != 0 & i % 5 != 0)
                element = i.ToString();

            yield return element;
        }
    }
}