namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Requests;

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
            //typeof(TraktSyncLastActivitiesRequest).IsSubclassOf(typeof(ATraktSingleItemGetRequest<TraktSyncLastActivities>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncLastActivitiesRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncLastActivitiesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncLastActivitiesRequestHasValidUriTemplate()
        {
            var request = new TraktSyncLastActivitiesRequest(null);
            request.UriTemplate.Should().Be("sync/last_activities");
        }
    }
}
