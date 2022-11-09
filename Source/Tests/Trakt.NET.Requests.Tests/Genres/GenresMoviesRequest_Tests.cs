namespace TraktNet.Requests.Tests.Genres
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Genres;
    using Xunit;

    [TestCategory("Requests.Genres")]
    public class GenresMoviesRequest_Tests
    {
        [Fact]
        public void Test_GenresMoviesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new GenresMoviesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_GenresMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new GenresMoviesRequest();
            request.UriTemplate.Should().Be("genres/movies");
        }

        [Fact]
        public void Test_GenresMoviesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new GenresMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
