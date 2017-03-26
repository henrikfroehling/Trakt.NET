namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.People;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Interfaces")]
    public class ITraktListItem_Tests
    {
        [Fact]
        public void Test_ITraktListItem_Is_Interface()
        {
            typeof(ITraktListItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktListItem_Has_Rank_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Rank");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktListItem_Has_ListedAt_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "ListedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktListItemType));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktListItem_Has_Person_Property()
        {
            var propertyInfo = typeof(ITraktListItem).GetProperties().FirstOrDefault(p => p.Name == "Person");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktPerson));
        }
    }
}
