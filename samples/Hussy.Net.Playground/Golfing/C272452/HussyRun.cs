namespace Hussy.Net.Playground.Golfing;

public sealed partial class C272452
{
    /// <summary>
    ///     The fully compressed and official Hussy.Net run.
    /// </summary>
    /// <param name="t">The stopping value for the test.</param>
    /// <returns>
    ///     A collection of strings representing the output for the specified <paramref name="t"/>.
    /// </returns>
    /// <remarks>
    ///     The final result yields <c>100</c> bytes.
    /// </remarks>
    private static IEnumerable<string> HussyRun(int t) =>
        Gr(t).M(i=>{string e=null;F(i,Dvb3,Dv3,_=>e+="Fizz");F(i,Dvb5,Dv5,_=>e+="Buzz");return e??i.Ts();});
}