namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserWatchingItem_Tests
    {
        [Fact]
        public void Test_ITraktUserWatchingItem_Is_Interface()
        {
            typeof(ITraktUserWatchingItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_StartedAt_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "StartedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_ExpiresAt_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "ExpiresAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_Action_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "Action");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktHistoryActionType));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncType));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktUserWatchingItem_Has_Episode_Property()
        {
            var propertyInfo = typeof(ITraktUserWatchingItem).GetProperties().FirstOrDefault(p => p.Name == "Episode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }
    }
}
