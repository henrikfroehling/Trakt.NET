namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class TraktSyncWatchedHistoryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsSealed()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }
    }
}
