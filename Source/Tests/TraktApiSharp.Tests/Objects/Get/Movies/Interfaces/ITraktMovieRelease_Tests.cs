namespace TraktApiSharp.Tests.Objects.Get.Movies.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMovieReleaseRelease_Tests
    {
        [Fact]
        public void Test_ITraktMovieRelease_Is_Interface()
        {
            typeof(ITraktMovieRelease).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovieRelease_Has_CountryCode_Property()
        {
            var propertyInfo = typeof(ITraktMovieRelease).GetProperties().FirstOrDefault(p => p.Name == "CountryCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovieRelease_Has_Certification_Property()
        {
            var propertyInfo = typeof(ITraktMovieRelease).GetProperties().FirstOrDefault(p => p.Name == "Certification");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovieRelease_Has_ReleaseDate_Property()
        {
            var propertyInfo = typeof(ITraktMovieRelease).GetProperties().FirstOrDefault(p => p.Name == "ReleaseDate");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktMovieRelease_Has_ReleaseType_Property()
        {
            var propertyInfo = typeof(ITraktMovieRelease).GetProperties().FirstOrDefault(p => p.Name == "ReleaseType");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktReleaseType));
        }

        [Fact]
        public void Test_ITraktMovieRelease_Has_Note_Property()
        {
            var propertyInfo = typeof(ITraktMovieRelease).GetProperties().FirstOrDefault(p => p.Name == "Note");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
