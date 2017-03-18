namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMostPWCMovie_Tests
    {
        [Fact]
        public void Test_ITraktMostPWCMovie_Is_Interface()
        {
            typeof(ITraktMostPWCMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMostPWCMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktMostPWCMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktMostPWCMovie_Has_WatcherCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCMovie).GetProperties().FirstOrDefault(p => p.Name == "WatcherCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCMovie_Has_PlayCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCMovie).GetProperties().FirstOrDefault(p => p.Name == "PlayCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCMovie_Has_CollectedCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCMovie).GetProperties().FirstOrDefault(p => p.Name == "CollectedCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
