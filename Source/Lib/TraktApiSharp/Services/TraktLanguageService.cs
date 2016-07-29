namespace TraktApiSharp.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Provides helper methods for converting two letter language codes into language names
    /// and converting two letter country codes into country names.
    /// </summary>
    public static class TraktLanguageService
    {
        /// <summary>
        /// Tries to look up the language name for the given language code.
        /// </summary>
        /// <param name="languageCode">The two letter language code, for which the language name should be looked up.</param>
        /// <returns>The language name for the given language code or an empty string, if not found.</returns>
        public static string GetLanguage(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return string.Empty;

            try
            {
                return new CultureInfo(languageCode).DisplayName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Tries to look up languages names for the given language codes.
        /// </summary>
        /// <param name="availableTranslationLanguageCodes">A list of two letter language codes, for which the language names should be looked up.</param>
        /// <returns>A list containing the found languages names. If the given language codes list is null or empty, an empty list will be returned.</returns>
        public static IEnumerable<string> GetAvailableTranslationLanguages(IEnumerable<string> availableTranslationLanguageCodes)
        {
            if (availableTranslationLanguageCodes == null || availableTranslationLanguageCodes.Count() <= 0)
                return new List<string>();

            var languages = new List<string>(availableTranslationLanguageCodes.Count());

            foreach (var languageCode in availableTranslationLanguageCodes)
            {
                try
                {
                    languages.Add(new RegionInfo(languageCode).DisplayName);
                }
                catch
                {
                    return new List<string>();
                }
            }

            return languages;
        }

        /// <summary>
        /// Tries to look up the country name for the given country code.
        /// </summary>
        /// <param name="countryCode">The two letter country code, for which the country name should be looked up.</param>
        /// <returns>The country name for the given country code or an empty string, if not found.</returns>
        public static string GetCountry(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                return string.Empty;

            try
            {
                return new RegionInfo(countryCode).DisplayName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
