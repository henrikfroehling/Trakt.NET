namespace TraktNet.Requests.Tests.Episodes
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Episodes;
    using Xunit;

    [TestCategory("Requests.Episodes")]
    public class EpisodeTranslationsRequest_Tests
    {
        [Fact]
        public void Test_EpisodeTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new EpisodeTranslationsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/translations{/language}");
        }

        [Fact]
        public void Test_EpisodeTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without language code
            var request = new EpisodeTranslationsRequest { Id = "123", EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1"
                                                   });

            // with explicit season number / without language code
            request = new EpisodeTranslationsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["episode"] = "1"
                                                   });

            // -------------------------------------------
            var languageCode = "en";

            // with implicit season number / with language code
            request = new EpisodeTranslationsRequest { Id = "123", EpisodeNumber = 1, LanguageCode = languageCode };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(4)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["episode"] = "1",
                                                       ["language"] = languageCode
                                                   });

            // with explicit season number / with language code
            request = new EpisodeTranslationsRequest { Id = "123", SeasonNumber = 2, EpisodeNumber = 1, LanguageCode = languageCode };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(4)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["episode"] = "1",
                                                       ["language"] = languageCode
                                                   });
        }

        [Fact]
        public void Test_EpisodeTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new EpisodeTranslationsRequest { EpisodeNumber = 1 };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new EpisodeTranslationsRequest { Id = string.Empty, EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new EpisodeTranslationsRequest { Id = "invalid id", EpisodeNumber = 1 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // episode number == 0
            request = new EpisodeTranslationsRequest { EpisodeNumber = 0 };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // language code with wrong length
            request = new EpisodeTranslationsRequest { Id = "123", EpisodeNumber = 1, LanguageCode = "eng" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            request = new EpisodeTranslationsRequest { Id = "123", EpisodeNumber = 1, LanguageCode = "e" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
