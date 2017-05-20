namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncCommentsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSyncCommentsLastActivitiesObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSyncCommentsLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSyncCommentsLastActivities>));
        }
    }
}
