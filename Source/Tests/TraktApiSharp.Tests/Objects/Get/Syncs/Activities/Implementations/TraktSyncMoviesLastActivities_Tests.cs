namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncMoviesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncMoviesLastActivities_Implements_ITraktSyncMoviesLastActivities_Interface()
        {
            typeof(TraktSyncMoviesLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncMoviesLastActivities));
        }
    }
}
