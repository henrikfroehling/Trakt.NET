namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktRecentlyUpdatedMovie_Tests
    {
        [Fact]
        public void Test_ITraktRecentlyUpdatedMovie_Is_Interface()
        {
            typeof(ITraktRecentlyUpdatedMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktRecentlyUpdatedMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovie_Has_RecentlyUpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktRecentlyUpdatedMovie).GetProperties().FirstOrDefault(p => p.Name == "RecentlyUpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktRecentlyUpdatedMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
