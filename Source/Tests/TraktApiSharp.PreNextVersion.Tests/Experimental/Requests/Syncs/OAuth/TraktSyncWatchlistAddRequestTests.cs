namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;

    [TestClass]
    public class TraktSyncWatchlistAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistAddRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchlistAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistAddRequestIsSealed()
        {
            typeof(TraktSyncWatchlistAddRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistAddRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncWatchlistAddRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistAddRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchlistAddRequest(null);
            request.UriTemplate.Should().Be("sync/watchlist");
        }
    }
}
