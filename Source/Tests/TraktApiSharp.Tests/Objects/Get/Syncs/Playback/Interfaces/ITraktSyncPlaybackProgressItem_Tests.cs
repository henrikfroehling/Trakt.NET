namespace TraktApiSharp.Tests.Objects.Get.Syncs.Playback.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using Xunit;

    [Category("Objects.Get.Syncs.Playback.Interfaces")]
    public class ITraktSyncPlaybackProgressItem_Tests
    {
        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Is_Interface()
        {
            typeof(ITraktSyncPlaybackProgressItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Progress_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Progress");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_PausedAt_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "PausedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncType));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }

        [Fact]
        public void Test_ITraktSyncPlaybackProgressItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktSyncPlaybackProgressItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
