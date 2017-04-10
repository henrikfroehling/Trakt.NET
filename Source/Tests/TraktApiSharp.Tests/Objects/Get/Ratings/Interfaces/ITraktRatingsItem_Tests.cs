namespace TraktApiSharp.Tests.Objects.Get.Ratings.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Ratings.Interfaces")]
    public class ITraktRatingsItem_Tests
    {
        [Fact]
        public void Test_ITraktRatingsItem_Is_Interface()
        {
            typeof(ITraktRatingsItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_RatedAt_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "RatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktRatingsItemType));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_ITraktRatingsItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktRatingsItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }
    }
}
