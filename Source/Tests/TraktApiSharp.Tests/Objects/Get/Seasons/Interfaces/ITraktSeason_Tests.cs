namespace TraktApiSharp.Tests.Objects.Get.Seasons.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Seasons;
    using Xunit;

    [Category("Objects.Get.Seasons.Interfaces")]
    public class ITraktSeason_Tests
    {
        [Fact]
        public void Test_ITraktSeason_Is_Interface()
        {
            typeof(ITraktSeason).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSeason_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeasonIds));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_TotalEpisodesCount_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "TotalEpisodesCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_AiredEpisodesCount_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "AiredEpisodesCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Overview_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Overview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktSeason_Has_FirstAired_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "FirstAired");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Network_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Network");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktSeason_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktSeason).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktEpisode>));
        }
    }
}
