namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Syncs.Activities;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncLastActivitiesRequestIsSubclassOfATraktSingleItemGetRequest()
        {
            typeof(TraktSyncLastActivitiesRequest).IsSubclassOf(typeof(ATraktSingleItemGetRequest<TraktSyncLastActivities>)).Should().BeTrue();
        }
    }
}
