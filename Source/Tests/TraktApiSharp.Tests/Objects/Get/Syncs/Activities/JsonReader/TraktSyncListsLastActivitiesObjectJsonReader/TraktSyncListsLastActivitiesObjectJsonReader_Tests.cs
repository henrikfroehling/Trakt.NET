namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncListsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSyncListsLastActivitiesObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSyncListsLastActivitiesObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktSyncListsLastActivities>));
        }
    }
}
