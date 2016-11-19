namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktEpisodeSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsNotAbstract()
        {
            typeof(TraktEpisodeSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsSealed()
        {
            typeof(TraktEpisodeSummaryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeSummaryRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestHasAuthorizationNotRequired()
        {
            var request = new TraktEpisodeSummaryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestHasValidUriTemplate()
        {
            var request = new TraktEpisodeSummaryRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/episodes/{episode}{?extended}");
        }
    }
}
