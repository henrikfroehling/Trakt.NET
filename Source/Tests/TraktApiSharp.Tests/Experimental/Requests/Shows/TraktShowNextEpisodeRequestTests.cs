namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowNextEpisodeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestIsNotAbstract()
        {
            typeof(TraktShowNextEpisodeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestIsSealed()
        {
            typeof(TraktShowNextEpisodeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktShowNextEpisodeRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowNextEpisodeRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestHasValidUriTemplate()
        {
            var request = new TraktShowNextEpisodeRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/next_episode{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktShowNextEpisodeRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
