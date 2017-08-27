namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserFollowUserRequest_Tests
    {
        [Fact]
        public void Test_UserFollowUserRequest_Is_Not_Abstract()
        {
            typeof(UserFollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserFollowUserRequest_Is_Sealed()
        {
            typeof(UserFollowUserRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowUserRequest_Inherits_ABodylessPostRequest_1()
        {
            typeof(UserFollowUserRequest).IsSubclassOf(typeof(ABodylessPostRequest<ITraktUserFollowUserPostResponse>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowUserRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserFollowUserRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserFollowUserRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserFollowUserRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserFollowUserRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFollowUserRequest();
            request.UriTemplate.Should().Be("users/{username}/follow");
        }

        [Fact]
        public void Test_UserFollowUserRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserFollowUserRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserFollowUserRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFollowUserRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserFollowUserRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserFollowUserRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
