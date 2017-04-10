namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisodeWatchedProgress_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeWatchedProgress_Is_Interface()
        {
            typeof(ITraktEpisodeWatchedProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgress_Inherits_ITraktEpisodeProgress_Interface()
        {
            typeof(ITraktEpisodeWatchedProgress).GetInterfaces().Should().Contain(typeof(ITraktEpisodeProgress));
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgress_Has_LastWatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeWatchedProgress).GetProperties().FirstOrDefault(p => p.Name == "LastWatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
