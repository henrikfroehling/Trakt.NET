namespace TraktApiSharp.Tests.Objects.Basic.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using Xunit;

    [Category("Objects.Basic.Interfaces")]
    public class ITraktIds_Tests
    {
        [Fact]
        public void Test_ITraktIds_Is_Interface()
        {
            typeof(ITraktIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktIds_Inherits_IIds_Interface()
        {
            typeof(ITraktIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktIds_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktIds_Has_Tvdb_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "Tvdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktIds_Has_Imdb_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "Imdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktIds_Has_Tmdb_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "Tmdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktIds_Has_TvRage_Property()
        {
            var propertyInfo = typeof(ITraktIds).GetProperties().FirstOrDefault(p => p.Name == "TvRage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
