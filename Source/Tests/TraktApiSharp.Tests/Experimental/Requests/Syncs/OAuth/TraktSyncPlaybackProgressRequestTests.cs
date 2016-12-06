namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class TraktSyncPlaybackProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsNotAbstract()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsSealed()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSealed.Should().BeTrue();
        }
    }
}
