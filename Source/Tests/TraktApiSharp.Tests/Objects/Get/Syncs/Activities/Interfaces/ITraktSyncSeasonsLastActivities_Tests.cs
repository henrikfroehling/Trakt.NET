namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Interfaces")]
    public class ITraktSyncSeasonsLastActivities_Tests
    {
        [Fact]
        public void Test_ITraktSyncSeasonsLastActivities_Is_Interface()
        {
            typeof(ITraktSyncSeasonsLastActivities).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncSeasonsLastActivities_Has_RatedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncSeasonsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "RatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncSeasonsLastActivities_Has_WatchlistedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncSeasonsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "WatchlistedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncSeasonsLastActivities_Has_CommentedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncSeasonsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "CommentedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncSeasonsLastActivities_Has_HiddenAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncSeasonsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "HiddenAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
