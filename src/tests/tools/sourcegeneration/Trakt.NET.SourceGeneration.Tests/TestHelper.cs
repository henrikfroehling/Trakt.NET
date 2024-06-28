using Basic.Reference.Assemblies;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace TraktNET.SourceGeneration
{
    internal enum RequestTestType
    {
        None,
        DeleteRequest,
        GetRequest,
        PostRequest,
        PutRequest
    }

    internal sealed class TestHelper
    {
        private const string SolutionRootDirectory = "../../../../../../..";
        private const string TraktNETLibraryRootDirectory = $"{SolutionRootDirectory}/libs/Trakt.NET";
        private const string TraktRequestAttributesDirectory = $"{TraktNETLibraryRootDirectory}/Internal/Attributes/Requests";
        private const string TraktDeleteRequestSourceFile = $"{TraktRequestAttributesDirectory}/TraktDeleteRequestAttribute.cs";
        private const string TraktGetRequestSourceFile = $"{TraktRequestAttributesDirectory}/TraktGetRequestAttribute.cs";
        private const string TraktPostRequestSourceFile = $"{TraktRequestAttributesDirectory}/TraktPostRequestAttribute.cs";
        private const string TraktPutRequestSourceFile = $"{TraktRequestAttributesDirectory}/TraktPutRequestAttribute.cs";

        internal static Task Verify<T>(string subDirectory, string compilationName, string source, RequestTestType requestTestType = RequestTestType.None) where T : IIncrementalGenerator, new()
        {
            IEnumerable<PortableExecutableReference> references = new[]
            {
                // Reference for this test project
                MetadataReference.CreateFromFile(typeof(TestHelper).Assembly.Location),

                // Reference for the Trakt library containing the attributes
                MetadataReference.CreateFromFile(typeof(TraktClient).Assembly.Location)
            };

            var syntaxTrees = new List<SyntaxTree>();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);
            syntaxTrees.Add(syntaxTree);

            if (requestTestType != RequestTestType.None)
            {
                // The request source generator looks up "DeclaringSyntaxReferences" for the attribute classes,
                // which is empty if the assembly is only added as MetadataReference, because the locations
                // of the attribute symbols are empty and their syntax trees are null.
                // To fix this, it is necessary to add the attributes syntax trees explicitly to the compilation.
                
                // NOTE: It's odd that adding all syntax trees at once still results in empty "DeclaringSyntaxReferences".
                //       Therefore only add the actual needed syntax tree for the specific request test case.

                switch (requestTestType)
                {
                    case RequestTestType.DeleteRequest:
                        SyntaxTree deleteRequestSyntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(TraktDeleteRequestSourceFile));
                        syntaxTrees.Add(deleteRequestSyntaxTree);
                        break;
                    case RequestTestType.GetRequest:
                        SyntaxTree getRequestSyntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(TraktGetRequestSourceFile));
                        syntaxTrees.Add(getRequestSyntaxTree);
                        break;
                    case RequestTestType.PostRequest:
                        SyntaxTree postRequestSyntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(TraktPostRequestSourceFile));
                        syntaxTrees.Add(postRequestSyntaxTree);
                        break;
                    case RequestTestType.PutRequest:
                        SyntaxTree putRequestSyntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(TraktPutRequestSourceFile));
                        syntaxTrees.Add(putRequestSyntaxTree);
                        break;
                }
            }

            // Trakt attributes are only accessible internally.
            // Set compilation options to import all symbols.
            CSharpCompilationOptions options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithMetadataImportOptions(MetadataImportOptions.All);

            // Fine tune binder flags accessibility.
            // Because "TopLevelBinderFlags" is not public, use some reflection trickery.
            PropertyInfo? topLevelBinderFlagsProperty = typeof(CSharpCompilationOptions)
                .GetProperty("TopLevelBinderFlags", BindingFlags.Instance | BindingFlags.NonPublic);

            topLevelBinderFlagsProperty?.SetValue(options, (uint)1 << 22);

            var compilation = CSharpCompilation.Create(
                assemblyName: compilationName,
                syntaxTrees: syntaxTrees,
                references: references, options: options);

            // Reference for the .NET 8 library
            compilation = compilation.AddReferences(ReferenceAssemblies.Net80);

            var generator = new T();
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            driver = driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out _);

            return Verifier.Verify(driver)
                .UseDirectory($"Snapshots/{subDirectory}")
                .ScrubLines(static x => x.StartsWith("//HintName", StringComparison.InvariantCulture));
        }
    }
}
