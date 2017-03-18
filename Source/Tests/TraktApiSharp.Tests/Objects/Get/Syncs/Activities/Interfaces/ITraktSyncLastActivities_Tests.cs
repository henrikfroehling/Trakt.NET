namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.Interfaces")]
    public class ITraktSyncLastActivities_Tests
    {
        [Fact]
        public void Test_ITraktSyncLastActivities_Is_Interface()
        {
            typeof(ITraktSyncLastActivities).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_All_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "All");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Movies_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Movies");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncMoviesLastActivities));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Shows_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Shows");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncShowsLastActivities));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncSeasonsLastActivities));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncEpisodesLastActivities));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Comments_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Comments");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncCommentsLastActivities));
        }

        [Fact]
        public void Test_ITraktSyncLastActivities_Has_Lists_Property()
        {
            var propertyInfo = typeof(ITraktSyncLastActivities).GetProperties().FirstOrDefault(p => p.Name == "Lists");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSyncListsLastActivities));
        }
    }
}
