namespace TraktApiSharp.Tests.Objects.Get.History.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.History.Interfaces")]
    public class ITraktHistoryItem_Tests
    {
        [Fact]
        public void Test_ITraktHistoryItem_Is_Interface()
        {
            typeof(ITraktHistoryItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ulong));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_WatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "WatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Action_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Action");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktHistoryActionType));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_ITraktHistoryItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktHistoryItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }
    }
}
