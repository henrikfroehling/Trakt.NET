namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Interfaces")]
    public class ITraktSyncMoviesLastActivities_Tests
    {
        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Is_Interface()
        {
            typeof(ITraktSyncMoviesLastActivities).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_WatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "WatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_CollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "CollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_RatedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "RatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_WatchlistedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "WatchlistedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_CommentedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "CommentedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_PausedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "PausedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncMoviesLastActivities_Has_HiddenAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncMoviesLastActivities).GetProperties().FirstOrDefault(p => p.Name == "HiddenAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
