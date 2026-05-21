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
using Microsoft.CodeAnalysis.CSharp.Testing;
using Xunit;
using AnalyzerVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.Display.ReverseAnalyzer>;
using CodeFixVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.CodeFixVerifier<
        Hussy.Net.Analyzers.Display.ReverseAnalyzer,
        Hussy.Net.Analyzers.Display.ReverseCodeFixProvider>;

namespace Hussy.Net.Analyzers.Tests.Display;

public class ReverseAnalyzerTests
{
    private const string RevStub = @"
public static class HussyStub
{
    public static string Rev<T>(T input) => string.Empty;
}
";

    [Fact]
    public async Task Reverse_CalledOnString_AlertDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var s = ""ABC"";
        var reversed = {|#0:new string(s.Reverse().ToArray())|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task Reverse_CalledOnToString_AlertDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = 123;
        var reversed = {|#0:new string(x.ToString().Reverse().ToArray())|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task Reverse_CalledOnCharArray_NoDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var chars = new[] { 'A', 'B', 'C' };
        var reversed = new string(chars.Reverse().ToArray());
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task Reverse_CalledOnToString_ReplacedWithRev()
    {
        var text = @"
using System.Linq;
using static HussyStub;

public class Program
{
    public void Main()
    {
        var x = 123;
        var reversed = {|#0:new string(x.ToString().Reverse().ToArray())|};
    }
}
"
                   + RevStub;

        var newText = @"
using System.Linq;
using static HussyStub;

public class Program
{
    public void Main()
    {
        var x = 123;
        var reversed = Rev(x);
    }
}
"
                      + RevStub;

        var expected = CodeFixVerifier.Diagnostic()
            .WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }
}
