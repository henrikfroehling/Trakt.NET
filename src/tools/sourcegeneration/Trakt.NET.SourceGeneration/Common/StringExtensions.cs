using System.Text.RegularExpressions;

namespace TraktNET.SourceGeneration.Common
{
    internal static class StringExtensions
    {
        internal static string ToLowercaseNamingConvention(this string value) => CapitalLetter.Replace(value, "_").ToLowerInvariant();

        internal static string ToDisplayName(this string value) => CapitalLetter.Replace(value, " ");

        private static readonly Regex CapitalLetter = new(@"(?<=[A-Z])(?=[A-Z][a-z]) | (?<=[^A-Z])(?=[A-Z]) | (?<=[A-Za-z])(?=[^A-Za-z])",
                                                          RegexOptions.IgnorePatternWhitespace);
    }
}
