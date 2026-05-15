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
using Microsoft.CodeAnalysis.Testing;
using Xunit;
using AnalyzerVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.Display.ToStringAnalyzer>;
using CodeFixVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.CodeFixVerifier<
        Hussy.Net.Analyzers.Display.ToStringAnalyzer,
        Hussy.Net.Analyzers.Display.ToStringCodeFixProvider>;

namespace Hussy.Net.Analyzers.Tests.Display;

public class ToStringAnalyzerTests
{
    // A stub extension providing Ts() so the fixed code compiles without an external reference.
    private const string TsStub = @"
public static class HussyStub
{
    public static string Ts<T>(this T input) => string.Empty;
}
";

    [Fact]
    public async Task ToString_CalledOnValue_AlertDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        var x = 42;
        var s = {|#0:x.ToString()|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task ToString_CalledOnNullable_AlertDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        int? x = null;
        var s = {|#0:x.ToString()|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task ToString_CalledOnBase_NoDiagnostic()
    {
        const string text = @"
public class Base
{
    public override string ToString() => base.ToString();
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task ToString_CalledOnValue_ReplacedWithTs()
    {
        var text = @"
public class Program
{
    public void Main()
    {
        var x = 42;
        var s = {|#0:x.ToString()|};
    }
}
" + TsStub;

        var newText = @"
public class Program
{
    public void Main()
    {
        var x = 42;
        var s = x.Ts();
    }
}
" + TsStub;

        var expected = CodeFixVerifier.Diagnostic()
            .WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }
}
