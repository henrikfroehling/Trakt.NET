namespace TraktApiSharp.Extensions
{
    using System;
    using System.Linq;

    /// <summary>Provides helper methods for strings.</summary>
    public static class StringExtensions
    {
        private static readonly char[] DelimiterChars = { ' ', ',', '.', ':', ';', '\n', '\t' };

        /// <summary>Converts the given string to a string, in which only the first letter is capitalized.</summary>
        /// <param name="value">The string, in which only the first letter should be capitalized.</param>
        /// <returns>A string, in which only the first letter is capitalized.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given string is null or empty.</exception>
        public static string FirstToUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value not valid", nameof(value));

            var trimmedValue = value.Trim();

            if (trimmedValue.Length > 1)
                return char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1).ToLower();

            return trimmedValue.ToUpper();
        }

        /// <summary>Counts the words in a string.</summary>
        /// <param name="value">The string, for which the words should be counted.</param>
        /// <returns>The number of words in the given string or zero, if the given string is null or empty.</returns>
        public static int WordCount(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            var words = value.Split(DelimiterChars);
            var filteredWords = words.Where(s => !string.IsNullOrEmpty(s));
            return filteredWords.Count();
        }

        /// <summary>Returns, whether the given string contains any spaces.</summary>
        /// <param name="value">The string, which should be checked.</param>
        /// <returns>True, if the given string contains any spaces, otherwise false.</returns>
        public static bool ContainsSpace(this string value)
        {
            return value.Contains(" ");
        }
    }
}
