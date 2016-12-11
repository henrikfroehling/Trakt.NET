namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;

    [TestClass]
    public class TraktSyncWatchedHistoryRemoveRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRemoveRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRemoveRequestIsSealed()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRemoveRequestIsSubclassOfATraktSyncSingleItemPostRequest()
        {
            typeof(TraktSyncWatchedHistoryRemoveRequest).IsSubclassOf(typeof(ATraktSyncSingleItemPostRequest<TraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>)).Should().BeTrue();
        }
    }
}
