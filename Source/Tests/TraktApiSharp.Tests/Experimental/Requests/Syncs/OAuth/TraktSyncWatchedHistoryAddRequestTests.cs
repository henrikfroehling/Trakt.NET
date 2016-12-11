namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;

    [TestClass]
    public class TraktSyncWatchedHistoryAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryAddRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryAddRequestIsSealed()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryAddRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncWatchedHistoryAddRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncHistoryPostResponse, TraktSyncHistoryPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryAddRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchedHistoryAddRequest(null);
            request.UriTemplate.Should().Be("sync/history");
        }
    }
}
