namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class TraktSyncLastActivitiesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncLastActivitiesRequestIsNotAbstract()
        {
            typeof(TraktSyncLastActivitiesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncLastActivitiesRequestIsSealed()
        {
            typeof(TraktSyncLastActivitiesRequest).IsSealed.Should().BeTrue();
        }
    }
}
