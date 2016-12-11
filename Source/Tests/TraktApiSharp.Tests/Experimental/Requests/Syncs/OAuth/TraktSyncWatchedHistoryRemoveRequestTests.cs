namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

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
    }
}
