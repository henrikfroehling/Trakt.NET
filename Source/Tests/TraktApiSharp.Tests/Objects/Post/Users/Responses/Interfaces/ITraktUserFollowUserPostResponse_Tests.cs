namespace TraktApiSharp.Tests.Objects.Post.Users.Responses.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using Xunit;

    [Category("Objects.Post.Users.Responses.Interfaces")]
    public class ITraktUserFollowUserPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktUserFollowUserPostResponse_Is_Interface()
        {
            typeof(ITraktUserFollowUserPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserFollowUserPostResponse_Has_ApprovedAt_Property()
        {
            var propertyInfo = typeof(ITraktUserFollowUserPostResponse).GetProperties().FirstOrDefault(p => p.Name == "ApprovedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktUserFollowUserPostResponse_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktUserFollowUserPostResponse).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }
    }
}
