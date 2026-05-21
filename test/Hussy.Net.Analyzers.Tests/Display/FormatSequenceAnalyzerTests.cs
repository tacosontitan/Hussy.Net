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

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using Xunit;
using AnalyzerVerifier =
    Microsoft.CodeAnalysis.CSharp.Testing.XUnit.AnalyzerVerifier<
        Hussy.Net.Analyzers.Display.FormatSequenceAnalyzer>;

namespace Hussy.Net.Analyzers.Tests.Display;

public class FormatSequenceAnalyzerTests
{
    private const string FsqStub = @"
using System.Collections.Generic;

public static class Hussy
{
    public static string Fsq<T>(IEnumerable<T> input, string separator = "", "") => string.Empty;
}
";

    [Fact]
    public async Task StringJoinWrappedInBrackets_AlertDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = {|#0:$""[{string.Join("", "", x)}]""|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task JsWrappedInBrackets_AlertDiagnostic()
    {
        var text = @"
using System.Collections.Generic;

public static class HussyStub
{
    public static string Js<T>(this IEnumerable<T> input, string separator = "", "") => string.Empty;
}

public class Program
{
    public void Main()
    {
        IEnumerable<int> x = new[] { 1, 2, 3 };
        var s = {|#0:$""[{x.Js()}]""|};
    }
}
";

        var expected = AnalyzerVerifier.Diagnostic()
            .WithLocation(0);
        await AnalyzerVerifier.VerifyAnalyzerAsync(text, expected);
    }

    [Fact]
    public async Task StringJoinWithoutBrackets_NoDiagnostic()
    {
        const string text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = string.Join("", "", x);
    }
}
";

        await AnalyzerVerifier.VerifyAnalyzerAsync(text);
    }

    [Fact]
    public async Task StringJoinWrappedInBrackets_ReplacedWithFsq()
    {
        var text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = $""[{string.Join("", "", x)}]"";
    }
}
"
                   + FsqStub;

        var newText = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = Hussy.Fsq(x);
    }
}
"
                      + FsqStub;

        await VerifyCodeFixAsync(text, newText);
    }

    [Fact]
    public async Task ConcatenationWrappedInBrackets_ReplacedWithFsqAndSeparator()
    {
        var text = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = ""["" + string.Join("" : "", x) + ""]"";
    }
}
"
                   + FsqStub;

        var newText = @"
using System.Linq;

public class Program
{
    public void Main()
    {
        var x = Enumerable.Range(1, 3);
        var s = Hussy.Fsq(x, "" : "");
    }
}
"
                      + FsqStub;

        await VerifyCodeFixAsync(text, newText);
    }

    private static async Task VerifyCodeFixAsync(string source, string expected)
    {
        using var workspace = new AdhocWorkspace();

        var projectId = ProjectId.CreateNewId();
        var documentId = DocumentId.CreateNewId(projectId);
        var solution = workspace.CurrentSolution
            .AddProject(projectId, "Tests", "Tests", LanguageNames.CSharp)
            .WithProjectParseOptions(projectId, new CSharpParseOptions(LanguageVersion.Preview))
            .WithProjectCompilationOptions(
                projectId,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
            .AddMetadataReferences(projectId, GetMetadataReferences())
            .AddDocument(documentId, "Test.cs", SourceText.From(source));

        var document = solution.GetDocument(documentId)!;
        var diagnostics = await GetAnalyzerDiagnosticsAsync(document);
        var diagnostic = Assert.Single(diagnostics);

        var actions = new List<CodeAction>();
        var provider = new global::Hussy.Net.Analyzers.Display.FormatSequenceCodeFixProvider();
        var context = new CodeFixContext(
            document,
            diagnostic,
            (action, _) => actions.Add(action),
            CancellationToken.None);

        await provider.RegisterCodeFixesAsync(context);
        var action = Assert.Single(actions);
        var operations = await action.GetOperationsAsync(CancellationToken.None);
        var changedSolution = Assert.Single(operations.OfType<ApplyChangesOperation>()).ChangedSolution;
        var updatedDocument = changedSolution.GetDocument(documentId);
        Assert.NotNull(updatedDocument);

        var actualText = await updatedDocument!.GetTextAsync();
        var actual = actualText.ToString(TextSpan.FromBounds(0, actualText.Length));
        Assert.Equal(NormalizeNewLines(expected), NormalizeNewLines(actual));
    }

    private static async Task<ImmutableArray<Diagnostic>> GetAnalyzerDiagnosticsAsync(Document document)
    {
        var compilation = await document.Project.GetCompilationAsync();
        Assert.NotNull(compilation);

        var analyzer = new global::Hussy.Net.Analyzers.Display.FormatSequenceAnalyzer();
        return await compilation!
            .WithAnalyzers(ImmutableArray.Create<DiagnosticAnalyzer>(analyzer))
            .GetAnalyzerDiagnosticsAsync();
    }

    private static IEnumerable<MetadataReference> GetMetadataReferences() =>
        ((string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES"))!
            .Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries)
            .Select(path => MetadataReference.CreateFromFile(path));

    private static string NormalizeNewLines(string text) =>
        text.Replace("\r\n", "\n");
}
