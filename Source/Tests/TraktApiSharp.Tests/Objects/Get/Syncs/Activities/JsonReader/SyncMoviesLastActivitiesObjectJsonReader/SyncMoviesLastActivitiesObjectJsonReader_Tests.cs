namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_SyncMoviesLastActivitiesObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(SyncMoviesLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSyncMoviesLastActivities>));
        }
    }
}
