using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Common
{
    internal static class DiagnosticDescriptors
    {
        private const string Category = "Trakt.NET.SourceGeneration";

        public static DiagnosticDescriptor InvalidTraktParameterEnumValue { get; } = new(
            id: "TRAKTNET1001",
            title: "Invalid parameter value for Trakt parameter enum.",
            messageFormat: "Parameter value for Trakt parameter enum is null or empty.",
            category: Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidDisplayNameValue { get; } = new(
            id: "TRAKTNET1002",
            title: "Invalid display name value for Trakt enum member.",
            messageFormat: "Display name for Trakt enum member is null.",
            category: Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);

        public static DiagnosticDescriptor InvalidJsonValue { get; } = new(
            id: "TRAKTNET1003",
            title: "Invalid json value for Trakt enum member.",
            messageFormat: "Json value for Trakt enum member is null.",
            category: Category,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true);
    }
}
