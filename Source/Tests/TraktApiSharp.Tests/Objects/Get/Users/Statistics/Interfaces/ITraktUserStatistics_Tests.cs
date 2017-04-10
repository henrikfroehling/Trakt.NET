namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Interfaces")]
    public class ITraktUserStatistics_Tests
    {
        [Fact]
        public void Test_ITraktUserStatistics_Is_Interface()
        {
            typeof(ITraktUserStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Movies_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Movies");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserMoviesStatistics));
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Shows_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Shows");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserShowsStatistics));
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserSeasonsStatistics));
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserEpisodesStatistics));
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Network_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Network");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserNetworkStatistics));
        }

        [Fact]
        public void Test_ITraktUserStatistics_Has_Ratings_Property()
        {
            var propertyInfo = typeof(ITraktUserStatistics).GetProperties().FirstOrDefault(p => p.Name == "Ratings");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUserRatingsStatistics));
        }
    }
}
