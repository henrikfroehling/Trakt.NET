namespace TraktNet.Core.Tests.Services
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Services;
    using Xunit;

    [Category("Services")]
    public class TraktLanguageService_Tests
    {
        [Fact]
        public void Test_TraktLanguageService_GetLanguage()
        {
            var language = TraktLanguageService.GetLanguage(null);
            language.Should().NotBeNull().And.BeEmpty();

            language = TraktLanguageService.GetLanguage(string.Empty);
            language.Should().NotBeNull().And.BeEmpty();

            language = TraktLanguageService.GetLanguage("definitive not a language code");
            language.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_TraktLanguageService_GetAvailableTranslationLanguages()
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

        [Fact]
        public void Test_TraktLanguageService_GetCountry()
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
