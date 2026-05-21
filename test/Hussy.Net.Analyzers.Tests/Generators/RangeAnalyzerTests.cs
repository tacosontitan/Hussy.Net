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

using System.Threading.Tasks;
using Xunit;
using AnalyzerVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.Generators.RangeAnalyzer>;
using CodeFixVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.CodeFixVerifier<
        Hussy.Net.Analyzers.Generators.RangeAnalyzer,
        Hussy.Net.Analyzers.Generators.RangeCodeFixProvider>;

namespace Hussy.Net.Analyzers.Tests.Generators;

public class RangeAnalyzerTests
{
    private const string GrStub = @"
public static class Hussy
{
    public static System.Collections.Generic.IEnumerable<int> Gr(int count) => System.Array.Empty<int>();
    public static System.Collections.Generic.IEnumerable<int> Gr(int start, int count) => System.Array.Empty<int>();
}
";

    [Fact]
    public async Task EnumerableRange_WithImplicitStart_AlertsDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main(int count)
    {
        var values = {|#0:Enumerable.Range(1, count)|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task EnumerableRange_WithExplicitStart_AlertsDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main(int start, int count)
    {
        var values = {|#0:Enumerable.Range(start, count)|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task SystemRange_NoDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        var range = new System.Range(1, 5);
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task EnumerableRange_WithImplicitStart_ReplacedWithGrCount()
    {
        var text = @"
using System.Linq;
using static Hussy;

public class Program
{
    public void Main(int count)
    {
        var values = {|#0:Enumerable.Range(1, count)|};
    }
}
"
        + GrStub;

        var newText = @"
using System.Linq;
using static Hussy;

public class Program
{
    public void Main(int count)
    {
        var values = Gr(count);
    }
}
"
        + GrStub;

        var expected = CodeFixVerifier.Diagnostic()
            .WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }

    [Fact]
    public async Task EnumerableRange_WithExplicitStart_ReplacedWithGrStartAndCount()
    {
        var text = @"
using System.Linq;
using static Hussy;

public class Program
{
    public void Main(int start, int count)
    {
        var values = {|#0:Enumerable.Range(start, count)|};
    }
}
"
        + GrStub;

        var newText = @"
using System.Linq;
using static Hussy;

public class Program
{
    public void Main(int start, int count)
    {
        var values = Gr(start, count);
    }
}
"
        + GrStub;

        var expected = CodeFixVerifier.Diagnostic()
            .WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }
}
