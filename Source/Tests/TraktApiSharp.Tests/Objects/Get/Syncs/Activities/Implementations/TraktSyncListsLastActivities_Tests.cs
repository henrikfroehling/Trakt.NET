namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncListsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncListsLastActivities_Implements_ITraktSyncListsLastActivities_Interface()
        {
            typeof(TraktSyncListsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncListsLastActivities));
        }
    }
}
