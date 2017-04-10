namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Interfaces")]
    public class ITraktUserShowsStatistics_Tests
    {
        [Fact]
        public void Test_ITraktUserShowsStatistics_Is_Interface()
        {
            typeof(ITraktUserShowsStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserShowsStatistics_Has_Watched_Property()
        {
            var propertyInfo = typeof(ITraktUserShowsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Watched");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserShowsStatistics_Has_Collected_Property()
        {
            var propertyInfo = typeof(ITraktUserShowsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Collected");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserShowsStatistics_Has_Ratings_Property()
        {
            var propertyInfo = typeof(ITraktUserShowsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Ratings");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserShowsStatistics_Has_Comments_Property()
        {
            var propertyInfo = typeof(ITraktUserShowsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Comments");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
