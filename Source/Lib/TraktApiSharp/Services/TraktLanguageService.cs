namespace TraktApiSharp.Services
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public static class TraktLanguageService
    {
        public static string GetLanguage(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return null;

            try
            {
                return new CultureInfo(languageCode).DisplayName;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static IEnumerable<string> GetAvailableTranslationLanguages(IEnumerable<string> availableTranslationLanguageCodes)
        {
            if (availableTranslationLanguageCodes == null || availableTranslationLanguageCodes.Count() <= 0)
                return null;

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

        public static string GetCountry(string countryCode)
        {
            if (string.IsNullOrEmpty(countryCode))
                return null;

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
