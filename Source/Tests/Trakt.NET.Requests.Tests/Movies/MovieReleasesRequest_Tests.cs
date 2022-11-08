namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies")]
    public class MovieReleasesRequest_Tests
    {
        [Fact]
        public void Test_MovieReleasesRequest_Has_Valid_UriTemplate()
        {
            var request = new MovieReleasesRequest();
            request.UriTemplate.Should().Be("movies/{id}/releases{/country}");
        }

        [Fact]
        public void Test_MovieReleasesRequest_Returns_Valid_UriPathParameters()
        {
            // without country code
            var request = new MovieReleasesRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });

            // with country code
            request = new MovieReleasesRequest { Id = "123", CountryCode = "us" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123",
                                                       ["country"] = "us"
                                                   });
        }

        [Fact]
        public void Test_MovieReleasesRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new MovieReleasesRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new MovieReleasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new MovieReleasesRequest { Id = "invalid id" };
            act.Should().Throw<TraktRequestValidationException>();

            // country code with wrong length
            request = new MovieReleasesRequest { Id = "123", CountryCode = "usa" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            request = new MovieReleasesRequest { Id = "123", CountryCode = "a" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
