/*
   Copyright 2024 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0
*/

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Xunit;
using AnalyzerVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.Display.FormatSequenceAnalyzer>;
using CodeFixVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.CodeFixVerifier<
        Hussy.Net.Analyzers.Display.FormatSequenceAnalyzer,
        Hussy.Net.Analyzers.Display.FormatSequenceCodeFixProvider>;

namespace Hussy.Net.Analyzers.Tests.Display;

public class FormatSequenceAnalyzerTests
{
    private const string FsqStub = @"
namespace Hussy.Net
{
    public static class Hussy
    {
        public static string Fsq<T>(System.Collections.Generic.IEnumerable<T> sequence, string separator = "", "") =>
            string.Empty;
    }
}";

    [Fact]
    public async Task FormatSequence_BracketedJoin_ReportsDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = {|#0:$""[{string.Join("", "", values)}]""|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic().WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task FormatSequence_UnbracketedJoin_NoDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = $""{string.Join("", "", values)}"";
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task FormatSequence_NullSeparator_NoDiagnostic()
    {
        const string text = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = $""[{string.Join((string)null, values)}]"";
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task FormatSequence_InsideFormatterImplementation_NoDiagnostic()
    {
        const string text = @"
namespace Hussy.Net
{
    public static class Hussy
    {
        public static string Fsq<T>(System.Collections.Generic.IEnumerable<T> sequence, string separator) =>
            $""[{string.Join(separator, sequence)}]"";
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task FormatSequence_BracketedJoin_ReplacedWithFsq()
    {
        var text = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = {|#0:$""[{string.Join("", "", values)}]""|};
    }
}
" + FsqStub;

        var newText = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = global::Hussy.Net.Hussy.Fsq(values);
    }
}
" + FsqStub;

        var expected = CodeFixVerifier.Diagnostic().WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }

    [Fact]
    public async Task FormatSequence_BracketedJoinWithCustomSeparator_PreservesSeparator()
    {
        var text = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = {|#0:$""[{string.Join("":"", values)}]""|};
    }
}
" + FsqStub;

        var newText = @"
public class Program
{
    public void Main()
    {
        var values = new[] { 1, 2, 3 };
        var output = global::Hussy.Net.Hussy.Fsq(values, "":"");
    }
}
" + FsqStub;

        var expected = CodeFixVerifier.Diagnostic().WithLocation(0);
        await CodeFixVerifier.VerifyCodeFixAsync(text, expected, newText);
    }
}
