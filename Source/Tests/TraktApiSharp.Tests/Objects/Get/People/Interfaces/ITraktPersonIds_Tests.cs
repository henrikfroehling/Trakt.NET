namespace TraktApiSharp.Tests.Objects.Get.People.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.People;
    using Xunit;

    [Category("Objects.Get.People.Interfaces")]
    public class ITraktPersonIds_Tests
    {
        [Fact]
        public void Test_ITraktPersonIds_Is_Interface()
        {
            typeof(ITraktPersonIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktPersonIds_Inherits_IIds_Interface()
        {
            typeof(ITraktPersonIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktPersonIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktPersonIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktPersonIds_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktPersonIds).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonIds_Has_Imdb_Property()
        {
            var propertyInfo = typeof(ITraktPersonIds).GetProperties().FirstOrDefault(p => p.Name == "Imdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktPersonIds_Has_Tmdb_Property()
        {
            var propertyInfo = typeof(ITraktPersonIds).GetProperties().FirstOrDefault(p => p.Name == "Tmdb");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }

        [Fact]
        public void Test_ITraktPersonIds_Has_TvRage_Property()
        {
            var propertyInfo = typeof(ITraktPersonIds).GetProperties().FirstOrDefault(p => p.Name == "TvRage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
