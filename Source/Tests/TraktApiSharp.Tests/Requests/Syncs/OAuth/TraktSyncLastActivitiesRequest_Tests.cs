namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncLastActivitiesRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncLastActivitiesRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncLastActivitiesRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncLastActivitiesRequest_Is_Sealed()
        {
            typeof(TraktSyncLastActivitiesRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncLastActivitiesRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncLastActivitiesRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktSyncLastActivities>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncLastActivitiesRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncLastActivitiesRequest();
            request.UriTemplate.Should().Be("sync/last_activities");
        }
    }
}
