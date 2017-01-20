namespace TraktApiSharp.Tests.Requests.Genres
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Genres;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Genres")]
    public class TraktGenresMoviesRequest_Tests
    {
        [Fact]
        public void Test_TraktGenresMoviesRequest_IsNotAbstract()
        {
            typeof(TraktGenresMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktGenresMoviesRequest_IsSealed()
        {
            typeof(TraktGenresMoviesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktGenresMoviesRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktGenresMoviesRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktGenre>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktGenresMoviesRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktGenresMoviesRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktGenresMoviesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktGenresMoviesRequest();
            request.UriTemplate.Should().Be("genres/movies");
        }

        [Fact]
        public void Test_TraktGenresMoviesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktGenresMoviesRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
