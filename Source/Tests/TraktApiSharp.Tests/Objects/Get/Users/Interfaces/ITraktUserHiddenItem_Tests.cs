namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserHiddenItem_Tests
    {
        [Fact]
        public void Test_ITraktUserHiddenItem_Is_Interface()
        {
            typeof(ITraktUserHiddenItem).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserHiddenItem_Has_HiddenAt_Property()
        {
            var propertyInfo = typeof(ITraktUserHiddenItem).GetProperties().FirstOrDefault(p => p.Name == "HiddenAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserHiddenItem_Has_Type_Property()
        {
            var propertyInfo = typeof(ITraktUserHiddenItem).GetProperties().FirstOrDefault(p => p.Name == "Type");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktHiddenItemType));
        }

        [Fact]
        public void Test_ITraktUserHiddenItem_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktUserHiddenItem).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktUserHiddenItem_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktUserHiddenItem).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktUserHiddenItem_Has_Season_Property()
        {
            var propertyInfo = typeof(ITraktUserHiddenItem).GetProperties().FirstOrDefault(p => p.Name == "Season");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSeason));
        }
    }
}
