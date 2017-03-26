namespace TraktApiSharp.Tests.Objects.Get.Watched.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched.Interfaces")]
    public class ITraktWatchedShow_Tests
    {
        [Fact]
        public void Test_ITraktWatchedShow_Is_Interface()
        {
            typeof(ITraktWatchedShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktWatchedShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktWatchedShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktWatchedShow_Has_Plays_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShow).GetProperties().FirstOrDefault(p => p.Name == "Plays");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktWatchedShow_Has_LastWatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShow).GetProperties().FirstOrDefault(p => p.Name == "LastWatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktWatchedShow_Has_WatchedSeasons_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShow).GetProperties().FirstOrDefault(p => p.Name == "WatchedSeasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktWatchedShowSeason>));
        }

        [Fact]
        public void Test_ITraktWatchedShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
