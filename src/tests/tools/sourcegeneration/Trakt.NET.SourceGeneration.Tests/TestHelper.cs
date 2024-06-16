using Basic.Reference.Assemblies;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace TraktNET.SourceGeneration
{
    internal sealed class TestHelper
    {
        internal static Task Verify<T>(string compilationName, string source) where T : IIncrementalGenerator, new()
        {
            IEnumerable<PortableExecutableReference> references = new[]
            {
                // Reference for this test project
                MetadataReference.CreateFromFile(typeof(TestHelper).Assembly.Location),

                // Reference for the Trakt library containing the attributes
                MetadataReference.CreateFromFile(typeof(TraktEnumAttribute).Assembly.Location)
            };

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

            // Trakt attributes are only accessible internally.
            // Set compilation options to import all symbols.
            CSharpCompilationOptions options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithMetadataImportOptions(MetadataImportOptions.All);

            // Fine tune binder flags accessibility.
            // Because "TopLevelBinderFlags" is not public, so use some reflection trickery.
            PropertyInfo? topLevelBinderFlagsProperty = typeof(CSharpCompilationOptions)
                .GetProperty("TopLevelBinderFlags", BindingFlags.Instance | BindingFlags.NonPublic);

            topLevelBinderFlagsProperty?.SetValue(options, (uint)1 << 22);

            var compilation = CSharpCompilation.Create(assemblyName: compilationName, syntaxTrees: new[] { syntaxTree },
                references: references, options: options);

            // Reference for the .NET 8 library
            compilation = compilation.AddReferences(ReferenceAssemblies.Net80);

            var generator = new T();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out _);
            GeneratorDriverRunResult results = driver.GetRunResult();

            results.GeneratedTrees.Length.Should().Be(1);

            SyntaxTree resultSyntaxTree = results.GeneratedTrees[0];
            string resultSource = resultSyntaxTree.ToString();

            return Verifier.Verify(resultSource).UseDirectory("Snapshots");
        }
    }
}
