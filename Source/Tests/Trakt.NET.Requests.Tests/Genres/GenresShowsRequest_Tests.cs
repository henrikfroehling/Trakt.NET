namespace TraktNet.Requests.Tests.Genres
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Genres;
    using Xunit;

    [TestCategory("Requests.Genres")]
    public class GenresShowsRequest_Tests
    {
        [Fact]
        public void Test_GenresShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new GenresShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_GenresShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new GenresShowsRequest();
            request.UriTemplate.Should().Be("genres/shows");
        }

        [Fact]
        public void Test_GenresShowsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new GenresShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
