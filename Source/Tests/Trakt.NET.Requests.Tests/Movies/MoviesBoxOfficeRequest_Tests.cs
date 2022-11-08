namespace TraktNet.Requests.Tests.Movies
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Movies;
    using Xunit;

    [TestCategory("Requests.Movies.Lists")]
    public class MoviesBoxOfficeRequest_Tests
    {
        [Fact]
        public void Test_MoviesBoxOfficeRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var requestMock = new MoviesBoxOfficeRequest();
            requestMock.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Has_Valid_UriTemplate()
        {
            var request = new MoviesBoxOfficeRequest();
            request.UriTemplate.Should().Be("movies/boxoffice{?extended}");
        }

        [Fact]
        public void Test_MoviesBoxOfficeRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new MoviesBoxOfficeRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new MoviesBoxOfficeRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
