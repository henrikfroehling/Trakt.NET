namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncEpisodesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncEpisodesLastActivities_Implements_ITraktSyncEpisodesLastActivities_Interface()
        {
            typeof(TraktSyncEpisodesLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncEpisodesLastActivities));
        }
    }
}
