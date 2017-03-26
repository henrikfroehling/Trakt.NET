namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Interfaces")]
    public class ITraktSyncListsLastActivities_Tests
    {
        [Fact]
        public void Test_ITraktSyncListsLastActivities_Is_Interface()
        {
            typeof(ITraktSyncListsLastActivities).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncListsLastActivities_Has_LikedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncListsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "LikedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncListsLastActivities_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncListsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncListsLastActivities_Has_CommentedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncListsLastActivities).GetProperties().FirstOrDefault(p => p.Name == "CommentedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
