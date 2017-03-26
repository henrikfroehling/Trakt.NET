namespace TraktApiSharp.Tests.Objects.Get.Movies.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMovieIds_Tests
    {
        [Fact]
        public void Test_ITraktMovieIds_Is_Interface()
        {
            typeof(ITraktMovieIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieIds_Inherits_IIds_Interface()
        {
            typeof(ITraktMovieIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktMovieIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktMovieIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktMovieIds_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktMovieIds).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovieIds_Has_Imdb_Property()
        {
            var propertyInfo = typeof(ITraktMovieIds).GetProperties().FirstOrDefault(p => p.Name == "Imdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovieIds_Has_Tmdb_Property()
        {
            var propertyInfo = typeof(ITraktMovieIds).GetProperties().FirstOrDefault(p => p.Name == "Tmdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
