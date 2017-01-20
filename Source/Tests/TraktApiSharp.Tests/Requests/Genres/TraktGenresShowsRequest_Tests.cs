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
    public class TraktGenresShowsRequest_Tests
    {
        [Fact]
        public void Test_TraktGenresShowsRequest_IsNotAbstract()
        {
            typeof(TraktGenresShowsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktGenresShowsRequest_IsSealed()
        {
            typeof(TraktGenresShowsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktGenresShowsRequest_Inherits_ATraktGetRequest_1()
        {
            typeof(TraktGenresShowsRequest).IsSubclassOf(typeof(ATraktGetRequest<TraktGenre>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktGenresShowsRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new TraktGenresShowsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_TraktGenresShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktGenresShowsRequest();
            request.UriTemplate.Should().Be("genres/shows");
        }

        [Fact]
        public void Test_TraktGenresShowsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktGenresShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
