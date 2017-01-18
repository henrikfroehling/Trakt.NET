namespace TraktApiSharp.Tests.Services
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Services;

    [TestClass]
    public class TraktLanguageServiceTests
    {
        [TestMethod]
        public void TestTraktLanguageServiceGetLanguage()
        {
            var language = TraktLanguageService.GetLanguage(null);
            language.Should().NotBeNull().And.BeEmpty();

            language = TraktLanguageService.GetLanguage(string.Empty);
            language.Should().NotBeNull().And.BeEmpty();

            language = TraktLanguageService.GetLanguage("definitive not a language code");
            language.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktLanguageServiceGetAvailableTranslationLanguages()
        {
            var languages = TraktLanguageService.GetAvailableTranslationLanguages(null);
            languages.Should().NotBeNull().And.BeEmpty();

            languages = TraktLanguageService.GetAvailableTranslationLanguages(new List<string>());
            languages.Should().NotBeNull().And.BeEmpty();

            languages = TraktLanguageService.GetAvailableTranslationLanguages(new List<string>()
            {
                "definitive not a language code 1", "definitive not a language code"
            });
            languages.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktLanguageServiceGetCountry()
        {
            var country = TraktLanguageService.GetCountry(null);
            country.Should().NotBeNull().And.BeEmpty();

            country = TraktLanguageService.GetCountry(string.Empty);
            country.Should().NotBeNull().And.BeEmpty();

            country = TraktLanguageService.GetCountry("definitive not a country code");
            country.Should().NotBeNull().And.BeEmpty();
        }
    }
}
