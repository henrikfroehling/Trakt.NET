namespace TraktApiSharp.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string FirstToUpper(this string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("value not valid");

            var trimmedValue = value.Trim();

            if (trimmedValue.Length > 1)
                return char.ToUpper(trimmedValue[0]) + trimmedValue.Substring(1).ToLower();

            return trimmedValue.ToUpper();
        }
    }
}
