namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSyncMoviesLastActivitiesObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSyncMoviesLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSyncMoviesLastActivities>));
        }
    }
}
