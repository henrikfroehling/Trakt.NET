namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncLastActivitiesRequest_Tests
    {
        [Fact]
        public void Test_SyncLastActivitiesRequest_Is_Not_Abstract()
        {
            typeof(SyncLastActivitiesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncLastActivitiesRequest_Is_Sealed()
        {
            typeof(SyncLastActivitiesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncLastActivitiesRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(SyncLastActivitiesRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktSyncLastActivities>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncLastActivitiesRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncLastActivitiesRequest();
            request.UriTemplate.Should().Be("sync/last_activities");
        }
    }
}
