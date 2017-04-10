namespace TraktApiSharp.Tests.Objects.Get.Watchlist.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Watchlist;
    using Xunit;

    [Category("Objects.Get.Watchlist.Interfaces")]
    public class ITraktWatchlistItem_Tests
    {
        [Fact]
        public void Test_ITraktWatchlistItem_Is_Interface()
        {
            typeof(ITraktWatchlistItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_ListedAt_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "ListedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_ITraktWatchlistItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktWatchlistItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }
    }
}
