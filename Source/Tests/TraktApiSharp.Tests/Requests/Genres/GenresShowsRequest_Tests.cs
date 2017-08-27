namespace TraktApiSharp.Tests.Requests.Genres
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Genres;
    using Xunit;

    [Category("Requests.Genres")]
    public class GenresShowsRequest_Tests
    {
        [Fact]
        public void Test_GenresMoviesRequest_IsNotAbstract()
        {
            typeof(GenresShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_GenresMoviesRequest_IsSealed()
        {
            typeof(GenresShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_GenresMoviesRequest_Inherits_AGetRequest_1()
        {
            typeof(GenresShowsRequest).IsSubclassOf(typeof(AGetRequest<ITraktGenre>)).Should().BeTrue();
        }

        [Fact]
        public void Test_GenresMoviesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new GenresShowsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_GenresMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new GenresShowsRequest();
            request.UriTemplate.Should().Be("genres/shows");
        }

        [Fact]
        public void Test_GenresMoviesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new GenresShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
