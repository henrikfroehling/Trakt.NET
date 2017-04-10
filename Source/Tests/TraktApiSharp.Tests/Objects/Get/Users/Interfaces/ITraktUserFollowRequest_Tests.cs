namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserFollowRequest_Tests
    {
        [Fact]
        public void Test_ITraktUserFollowRequest_Is_Interface()
        {
            typeof(ITraktUserFollowRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserFollowRequest_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktUserFollowRequest).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktUserFollowRequest_Has_RequestedAt_Property()
        {
            var propertyInfo = typeof(ITraktUserFollowRequest).GetProperties().FirstOrDefault(p => p.Name == "RequestedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserFollowRequest_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktUserFollowRequest).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
