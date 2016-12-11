namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class TraktSyncRatingsAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestIsNotAbstract()
        {
            typeof(TraktSyncRatingsAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncRatingsAddRequestIsSealed()
        {
            typeof(TraktSyncRatingsAddRequest).IsSealed.Should().BeTrue();
        }
    }
}
