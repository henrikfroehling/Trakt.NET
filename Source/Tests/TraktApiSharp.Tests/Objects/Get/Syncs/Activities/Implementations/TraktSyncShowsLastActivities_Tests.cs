namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncShowsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncShowsLastActivities_Implements_ITraktSyncShowsLastActivities_Interface()
        {
            typeof(TraktSyncShowsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncShowsLastActivities));
        }
    }
}
