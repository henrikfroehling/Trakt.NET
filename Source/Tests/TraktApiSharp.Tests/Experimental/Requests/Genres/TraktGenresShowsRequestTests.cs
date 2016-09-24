namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Genres;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktGenresShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestIsNotAbstract()
        {
            typeof(TraktGenresShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestIsSealed()
        {
            typeof(TraktGenresShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestIsSubclassOfATraktGenresRequest()
        {
            typeof(TraktGenresShowsRequest).IsSubclassOf(typeof(ATraktGenresRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktGenresShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestHasValidUriTemplate()
        {
            var request = new TraktGenresShowsRequest(null);
            request.UriTemplate.Should().Be("genres/shows");
        }
    }
}
