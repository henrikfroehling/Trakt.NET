namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Implementations;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncCommentsLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncCommentsLastActivities_Implements_ITraktSyncCommentsLastActivities_Interface()
        {
            typeof(TraktSyncCommentsLastActivities).GetInterfaces().Should().Contain(typeof(ITraktSyncCommentsLastActivities));
        }
    }
}
