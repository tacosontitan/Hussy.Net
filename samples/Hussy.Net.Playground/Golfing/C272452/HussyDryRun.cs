namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    /// <summary>
    /// The hussy run simply compresses the golfed dry run.
    /// </summary>
    /// <param name="t">The stopping value for the test.</param>
    /// <returns>
    ///     A collection of strings representing the output for the specified <paramref name="target"/>.
    /// </returns>
    /// <remarks>
    ///     Fully condensed, this method body becomes <c>156</c> bytes.
    /// </remarks>
    private static IEnumerable<string> HussyDryRun(int t)
    {
        var results = new List<string>(capacity: t);
        Gr(t).E(i =>
        {
            string e = null;
            F(i, Dvb3, Dv3, _ => e += "Fizz");
            F(i, Dvb3, Dv5, _ => e += "Buzz");
            results.Add(e ?? i.Ts());
        });

        return results;
    }
}