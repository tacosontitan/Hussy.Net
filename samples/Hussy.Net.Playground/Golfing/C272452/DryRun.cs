namespace Hussy.Net.Playground.Golfing;

public sealed partial class C270154
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
        for (var i = 1; i < target; i++)
        {
            if (i % 3 != 0 && i % 5 != 0)
            {
                yield return i.ToString();
                continue;
            }

            var fizz = "";
            var tempFizz = i;
            while (i % 3 == 0 && tempFizz > 0)
            {
                tempFizz /= 3;
                fizz += "Fizz";
            }

            var buzz = "";
            var tempBuzz = i;
            while (i % 5 == 0 && tempBuzz > 0)
            {
                tempBuzz /= 5;
                buzz += "Buzz";
            }

            yield return fizz + buzz;
        }
    }
}