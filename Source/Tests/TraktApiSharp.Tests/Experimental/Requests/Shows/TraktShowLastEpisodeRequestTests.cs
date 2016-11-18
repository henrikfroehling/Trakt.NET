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
    public class TraktShowLastEpisodeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestIsNotAbstract()
        {
            typeof(TraktShowLastEpisodeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestIsSealed()
        {
            typeof(TraktShowLastEpisodeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktShowLastEpisodeRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowLastEpisodeRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestHasValidUriTemplate()
        {
            var request = new TraktShowLastEpisodeRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/last_episode{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktShowLastEpisodeRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
