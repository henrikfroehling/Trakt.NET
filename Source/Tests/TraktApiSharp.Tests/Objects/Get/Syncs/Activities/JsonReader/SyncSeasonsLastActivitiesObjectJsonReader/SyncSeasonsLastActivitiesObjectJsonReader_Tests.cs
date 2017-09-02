namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncSeasonsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncSeasonsLastActivitiesObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SyncSeasonsLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSyncSeasonsLastActivities>));
        }
    }
}
