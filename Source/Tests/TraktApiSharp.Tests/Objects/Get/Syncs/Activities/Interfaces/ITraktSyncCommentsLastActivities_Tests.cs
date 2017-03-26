namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Interfaces")]
    public class ITraktSyncCommentsLastActivities_Tests
    {
        [Fact]
        public void Test_ITraktSyncCommentsLastActivities_Is_Interface()
        {
            typeof(ITraktSyncCommentsLastActivities).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncCommentsLastActivities_Has_LikedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncCommentsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "LikedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
