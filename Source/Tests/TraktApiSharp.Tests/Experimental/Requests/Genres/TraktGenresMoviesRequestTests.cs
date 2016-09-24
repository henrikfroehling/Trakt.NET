namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Genres;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktGenresMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestIsNotAbstract()
        {
            typeof(TraktGenresMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestIsSealed()
        {
            typeof(TraktGenresMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestIsSubclassOfATraktGenresRequest()
        {
            typeof(TraktGenresMoviesRequest).IsSubclassOf(typeof(ATraktGenresRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestHasAuthorizationNotRequired()
        {
            var request = new TraktGenresMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktGenresMoviesRequest(null);
            request.UriTemplate.Should().Be("genres/movies");
        }
    }
}
