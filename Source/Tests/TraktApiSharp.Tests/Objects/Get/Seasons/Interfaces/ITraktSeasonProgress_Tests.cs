namespace TraktApiSharp.Tests.Objects.Get.Seasons.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using Xunit;

    [Category("Objects.Get.Seasons.Interfaces")]
    public class ITraktSeasonProgress_Tests
    {
        [Fact]
        public void Test_ITraktSeasonProgress_Is_Interface()
        {
            typeof(ITraktSeasonProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSeasonProgress_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktSeasonProgress).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeasonProgress_Has_Aired_Property()
        {
            var propertyInfo = typeof(ITraktSeasonProgress).GetProperties().FirstOrDefault(p => p.Name == "Aired");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktSeasonProgress_Has_Completed_Property()
        {
            var propertyInfo = typeof(ITraktSeasonProgress).GetProperties().FirstOrDefault(p => p.Name == "Completed");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }
    }
}
