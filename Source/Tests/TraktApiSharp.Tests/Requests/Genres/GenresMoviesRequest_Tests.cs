namespace TraktApiSharp.Tests.Requests.Genres
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Genres;
    using Xunit;

    [Category("Requests.Genres")]
    public class GenresMoviesRequest_Tests
    {
        [Fact]
        public void Test_GenresMoviesRequest_IsNotAbstract()
        {
            typeof(GenresMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_GenresMoviesRequest_IsSealed()
        {
            typeof(GenresMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_GenresMoviesRequest_Inherits_AGetRequest_1()
        {
            typeof(GenresMoviesRequest).IsSubclassOf(typeof(AGetRequest<ITraktGenre>)).Should().BeTrue();
        }

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
