namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncLastActivitiesObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SyncLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSyncLastActivities>));
        }
    }
}
