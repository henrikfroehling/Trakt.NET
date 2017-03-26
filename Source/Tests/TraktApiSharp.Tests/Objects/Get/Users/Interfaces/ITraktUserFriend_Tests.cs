namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserFriend_Tests
    {
        [Fact]
        public void Test_ITraktUserFriend_Is_Interface()
        {
            typeof(ITraktUserFriend).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserFriend_Inherits_ITraktUser_Interface()
        {
            typeof(ITraktUserFriend).GetInterfaces().Should().Contain(typeof(ITraktUser));
        }

        [Fact]
        public void Test_ITraktUserFriend_Has_FriendsAt_Property()
        {
            var propertyInfo = typeof(ITraktUserFriend).GetProperties().FirstOrDefault(p => p.Name == "FriendsAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserFriend_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktUserFriend).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
