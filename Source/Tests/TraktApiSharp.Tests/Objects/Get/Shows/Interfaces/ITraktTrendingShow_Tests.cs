namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktTrendingShow_Tests
    {
        [Fact]
        public void Test_ITraktTrendingShow_Is_Interface()
        {
            typeof(ITraktTrendingShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktTrendingShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktTrendingShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktTrendingShow_Has_Watchers_Property()
        {
            var propertyInfo = typeof(ITraktTrendingShow).GetProperties().FirstOrDefault(p => p.Name == "Watchers");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktTrendingShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktTrendingShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
