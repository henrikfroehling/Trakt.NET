namespace TraktApiSharp.Tests.Objects.Get.Seasons.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Seasons;
    using Xunit;

    [Category("Objects.Get.Seasons.Interfaces")]
    public class ITraktSeasonIds_Tests
    {
        [Fact]
        public void Test_ITraktSeasonIds_Is_Interface()
        {
            typeof(ITraktSeasonIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSeasonIds_Inherits_IIds_Interface()
        {
            typeof(ITraktSeasonIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktSeasonIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktSeasonIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktSeasonIds_Has_Tvdb_Property()
        {
            var propertyInfo = typeof(ITraktSeasonIds).GetProperties().FirstOrDefault(p => p.Name == "Tvdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktSeasonIds_Has_Tmdb_Property()
        {
            var propertyInfo = typeof(ITraktSeasonIds).GetProperties().FirstOrDefault(p => p.Name == "Tmdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktSeasonIds_Has_TvRage_Property()
        {
            var propertyInfo = typeof(ITraktSeasonIds).GetProperties().FirstOrDefault(p => p.Name == "TvRage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
