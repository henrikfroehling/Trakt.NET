namespace TraktApiSharp.Tests.Objects.Get.Movies.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktTrendingMovie_Tests
    {
        [Fact]
        public void Test_ITraktTrendingMovie_Is_Interface()
        {
            typeof(ITraktTrendingMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktTrendingMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktTrendingMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktTrendingMovie_Has_Watchers_Property()
        {
            var propertyInfo = typeof(ITraktTrendingMovie).GetProperties().FirstOrDefault(p => p.Name == "Watchers");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktTrendingMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktTrendingMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
