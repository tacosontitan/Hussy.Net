using Xunit;
using Verifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.SampleSemanticAnalyzer>;

namespace Hussy.Net.Analyzers.Tests;

public class SampleSemanticAnalyzerTests
{
    [Fact]
    public async Task SetSpeedHugeSpeedSpecified_AlertDiagnostic()
    {
        const string text =
            """
            public class Program
            {
                public void Main()
                {
                    Console.WriteLine("...");
                }
            }
            """;

        var expected = Verifier.Diagnostic()
            .WithLocation(5, 9);
        
        await Verifier.VerifyAnalyzerAsync(text, expected);
    }
}