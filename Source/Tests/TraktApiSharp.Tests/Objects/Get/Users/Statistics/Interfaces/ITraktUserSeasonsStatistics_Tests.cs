namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Interfaces")]
    public class ITraktUserSeasonsStatistics_Tests
    {
        [Fact]
        public void Test_ITraktUserSeasonsStatistics_Is_Interface()
        {
            typeof(ITraktUserSeasonsStatistics).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserSeasonsStatistics_Has_Ratings_Property()
        {
            var propertyInfo = typeof(ITraktUserSeasonsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Ratings");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktUserSeasonsStatistics_Has_Comments_Property()
        {
            var propertyInfo = typeof(ITraktUserSeasonsStatistics).GetProperties().FirstOrDefault(p => p.Name == "Comments");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
