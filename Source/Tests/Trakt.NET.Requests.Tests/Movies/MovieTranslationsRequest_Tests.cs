namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieTranslationsRequest_Tests
    {
        [Fact]
        public void Test_MovieTranslationsRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieTranslationsRequest();
            request.UriTemplate.Should().Be("movies/{id}/translations{/language}");
        }

        [Fact]
        public void Test_MovieTranslationsRequest_Returns_Valid_UriPathParameters()
        {
            // without language code
            var request = new MovieTranslationsRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with language code
            request = new MovieTranslationsRequest { Id = "123", LanguageCode = "en" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["language"] = "en"
                                                   });
        }

        [Fact]
        public void Test_MovieTranslationsRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieTranslationsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MovieTranslationsRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MovieTranslationsRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();

            // language code with wrong length
            request = new MovieTranslationsRequest { Id = "123", LanguageCode = "eng" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();

            request = new MovieTranslationsRequest { Id = "123", LanguageCode = "e" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
