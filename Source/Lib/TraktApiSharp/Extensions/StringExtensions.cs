namespace TraktApiSharp.Extensions
{
    using System;
    using System.Linq;

    public static class StringExtensions
    {
        private static readonly char[] DelimiterChars = { ' ', ',', '.', ':', ';', '\n', '\t' };

        public static string FirstToUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value not valid");

            var trimmedValue = value.Trim();

            if (trimmedValue.Length > 1)
                return char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1).ToLower();

            return trimmedValue.ToUpper();
        }

        public static int WordCount(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            var words = value.Split(DelimiterChars);
            var filteredWords = words.Where(s => !string.IsNullOrEmpty(s));
            return filteredWords.Count();
        }
    }
}
