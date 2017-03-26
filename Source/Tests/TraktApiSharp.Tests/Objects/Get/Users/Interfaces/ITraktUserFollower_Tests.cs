namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserFollower_Tests
    {
        [Fact]
        public void Test_ITraktUserFollower_Is_Interface()
        {
            typeof(ITraktUserFollower).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserFollower_Inherits_ITraktUser_Interface()
        {
            typeof(ITraktUserFollower).GetInterfaces().Should().Contain(typeof(ITraktUser));
        }

        [Fact]
        public void Test_ITraktUserFollower_Has_FollowedAt_Property()
        {
            var propertyInfo = typeof(ITraktUserFollower).GetProperties().FirstOrDefault(p => p.Name == "FollowedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserFollower_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktUserFollower).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
