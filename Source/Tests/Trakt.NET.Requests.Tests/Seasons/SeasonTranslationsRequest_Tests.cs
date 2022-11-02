namespace TraktNet.Requests.Tests.Seasons
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Seasons;
    using Xunit;

    [TestCategory("Requests.Seasons")]
    public class SeasonTranslationsRequest_Tests
    {
        [Fact]
        public void Test_SeasonTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new SeasonTranslationsRequest();
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/translations{/language}");
        }

        [Fact]
        public void Test_SeasonTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // with implicit season number / without language code
            var request = new SeasonTranslationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0"
                                                   });

            // with explicit season number / without language code
            request = new SeasonTranslationsRequest { Id = "123", SeasonNumber = 2 };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2"
                                                   });

            // with implicit season number / with language code
            request = new SeasonTranslationsRequest { Id = "123", LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "0",
                                                       ["language"] = "en"
                                                   });

            // with explicit season number / with language code
            request = new SeasonTranslationsRequest { Id = "123", SeasonNumber = 2, LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["season"] = "2",
                                                       ["language"] = "en"
                                                   });
        }

        [Fact]
        public void Test_SeasonTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new SeasonTranslationsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new SeasonTranslationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new SeasonTranslationsRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // language code with wrong length
            request = new SeasonTranslationsRequest { Id = "123", LanguageCode = "eng" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            request = new SeasonTranslationsRequest { Id = "123", LanguageCode = "e" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
