namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisodeIds_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeIds_Is_Interface()
        {
            typeof(ITraktEpisodeIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Inherits_IIds_Interface()
        {
            typeof(ITraktEpisodeIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Has_Tvdb_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeIds).GetProperties().FirstOrDefault(p => p.Name == "Tvdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Has_Imdb_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeIds).GetProperties().FirstOrDefault(p => p.Name == "Imdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Has_Tmdb_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeIds).GetProperties().FirstOrDefault(p => p.Name == "Tmdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktEpisodeIds_Has_TvRage_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeIds).GetProperties().FirstOrDefault(p => p.Name == "TvRage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
