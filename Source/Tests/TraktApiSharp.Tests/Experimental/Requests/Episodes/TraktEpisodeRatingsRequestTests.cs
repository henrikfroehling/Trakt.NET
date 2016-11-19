namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktEpisodeRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsSealed()
        {
            typeof(TraktEpisodeRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktEpisodeRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeRatingsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}/ratings");
        }
    }
}
