namespace TraktApiSharp.Tests.Objects.Get.Watched.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched.Interfaces")]
    public class ITraktWatchedMovie_Tests
    {
        [Fact]
        public void Test_ITraktWatchedMovie_Is_Interface()
        {
            typeof(ITraktWatchedMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktWatchedMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktWatchedMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktWatchedMovie_Has_Plays_Property()
        {
            var propertyInfo = typeof(ITraktWatchedMovie).GetProperties().FirstOrDefault(p => p.Name == "Plays");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktWatchedMovie_Has_LastWatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktWatchedMovie).GetProperties().FirstOrDefault(p => p.Name == "LastWatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktWatchedMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktWatchedMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
