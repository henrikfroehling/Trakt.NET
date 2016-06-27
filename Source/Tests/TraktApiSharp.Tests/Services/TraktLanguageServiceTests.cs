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
            language.Should().BeNull();

            language = TraktLanguageService.GetLanguage(string.Empty);
            language.Should().BeNull();

            language = TraktLanguageService.GetLanguage("definitive not a language code");
            language.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktLanguageServiceGetAvailableTranslationLanguages()
        {
            var languages = TraktLanguageService.GetAvailableTranslationLanguages(null);
            languages.Should().BeNull();

            languages = TraktLanguageService.GetAvailableTranslationLanguages(new List<string>());
            languages.Should().BeNull();

            languages = TraktLanguageService.GetAvailableTranslationLanguages(new List<string>()
            {
                "definitive not a language code 1", "definitive not a language code 2"
            });
            languages.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktLanguageServiceGetCountry()
        {
            var country = TraktLanguageService.GetCountry(null);
            country.Should().BeNull();

            country = TraktLanguageService.GetCountry(string.Empty);
            country.Should().BeNull();

            country = TraktLanguageService.GetCountry("definitive not a country code");
            country.Should().NotBeNull().And.BeEmpty();
        }
    }
}
