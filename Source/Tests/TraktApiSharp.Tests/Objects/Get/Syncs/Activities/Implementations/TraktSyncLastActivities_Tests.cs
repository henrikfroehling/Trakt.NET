namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncLastActivities_Implements_ITraktSyncLastActivities_Interface()
        {
            typeof(TraktSyncLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncLastActivities));
        }
    }
}
