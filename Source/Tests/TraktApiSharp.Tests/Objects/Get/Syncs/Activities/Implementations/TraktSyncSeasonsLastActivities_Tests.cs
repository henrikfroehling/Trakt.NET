namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncSeasonsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncSeasonsLastActivities_Implements_ITraktSyncSeasonsLastActivities_Interface()
        {
            typeof(TraktSyncSeasonsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncSeasonsLastActivities));
        }
    }
}
