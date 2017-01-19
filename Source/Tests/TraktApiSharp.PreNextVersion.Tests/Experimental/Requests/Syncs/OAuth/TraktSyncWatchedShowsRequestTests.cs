namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncWatchedShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsSealed()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestIsSubclassOfATraktSyncListGetRequest()
        {
            typeof(TraktSyncWatchedShowsRequest).IsSubclassOf(typeof(ATraktSyncListGetRequest<TraktWatchedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSyncWatchedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncWatchedShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedShowsRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchedShowsRequest(null);
            request.UriTemplate.Should().Be("sync/watched/shows{?extended}");
        }
    }
}
