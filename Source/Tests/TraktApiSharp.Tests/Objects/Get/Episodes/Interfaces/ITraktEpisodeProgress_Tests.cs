namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisodeProgress_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeProgress_Is_Interface()
        {
            typeof(ITraktEpisodeProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeProgress_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeProgress).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisodeProgress_Has_Completed_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeProgress).GetProperties().FirstOrDefault(p => p.Name == "Completed");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }
    }
}
