using System.Runtime.CompilerServices;

namespace TraktNET.SourceGeneration
{
    public static class TestInitializer
    {
        [ModuleInitializer]
        public static void Init() => VerifySourceGenerators.Initialize();
    }
}
