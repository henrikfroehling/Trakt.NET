namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncWatchlistRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchlistRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsSealed()
        {
            typeof(TraktSyncWatchlistRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsSubclassOfATraktSyncPaginationRequest()
        {
            typeof(TraktSyncWatchlistRequest).IsSubclassOf(typeof(ATraktSyncPaginationRequest<TraktWatchlistItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncWatchlistRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchlistRequest(null);
            request.UriTemplate.Should().Be("sync/watchlist{/type}{?extended,page,limit}");
        }
    }
}
