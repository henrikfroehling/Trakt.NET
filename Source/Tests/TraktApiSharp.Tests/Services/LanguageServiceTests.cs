namespace TraktApiSharp.Tests.Services
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using TraktApiSharp.Services;

    [TestClass]
    public class LanguageServiceTests
    {
        [TestMethod]
        public void TestLanguageServiceGetLanguage()
        {
            var language = LanguageService.GetLanguage(null);
            language.Should().BeNull();

            language = LanguageService.GetLanguage(string.Empty);
            language.Should().BeNull();

            language = LanguageService.GetLanguage("definitive not a language code");
            language.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestLanguageServiceGetAvailableTranslationLanguages()
        {
            var languages = LanguageService.GetAvailableTranslationLanguages(null);
            languages.Should().BeNull();

            languages = LanguageService.GetAvailableTranslationLanguages(new List<string>());
            languages.Should().BeNull();

            languages = LanguageService.GetAvailableTranslationLanguages(new List<string>()
            {
                "definitive not a language code 1", "definitive not a language code 2"
            });
            languages.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestLanguageServiceGetCountry()
        {
            var country = LanguageService.GetCountry(null);
            country.Should().BeNull();

            country = LanguageService.GetCountry(string.Empty);
            country.Should().BeNull();

            country = LanguageService.GetCountry("definitive not a country code");
            country.Should().NotBeNull().And.BeEmpty();
        }
    }
}
