namespace TraktApiSharp.Tests.Objects.Get.Watched.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched.Interfaces")]
    public class ITraktWatchedShowEpisodeEpisode_Tests
    {
        [Fact]
        public void Test_ITraktWatchedShowEpisode_Is_Interface()
        {
            typeof(ITraktWatchedShowEpisode).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktWatchedShowEpisode_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktWatchedShowEpisode_Has_Plays_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "Plays");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktWatchedShowEpisode_Has_LastWatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "LastWatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
