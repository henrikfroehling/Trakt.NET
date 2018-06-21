namespace TraktNet.Tests.Requests.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktNet.Requests.Movies;
    using Xunit;

    [Category("Requests.Movies")]
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
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new MovieReleasesRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new MovieReleasesRequest { Id = "invalid id" };
            act.Should().Throw<ArgumentException>();

            // country code with wrong length
            request = new MovieReleasesRequest { Id = "123", CountryCode = "usa" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();

            request = new MovieReleasesRequest { Id = "123", CountryCode = "a" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
