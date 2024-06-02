namespace TraktNET.SourceGeneration.Common
{
    internal static class Constants
    {
        internal const string LibraryNamespace = "TraktNET";

        internal const string Header = """
            //-----------------------------------------------------------------------------------------------------
            // <auto-generated>
            //     This code was generated by a Trakt.NET source generator.
            //     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
            // </auto-generated>
            //-----------------------------------------------------------------------------------------------------

            #nullable enable

            """;

        internal const string ExcludeCodeCoverage = """
            #if NET5_0_OR_GREATER
                [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage(Justification = "Generated by a Trakt.NET source generator.")]
            #else
                [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            #endif
            """;

        internal const string GeneratedFilenameSuffix = ".g.cs";

        internal const string FullSystemFlagsAttributeName = "System.FlagsAttribute";
    }
}
