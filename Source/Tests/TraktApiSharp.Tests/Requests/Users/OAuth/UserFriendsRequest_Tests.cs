namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserFriendsRequest_Tests
    {
        [Fact]
        public void Test_UserFriendsRequest_Is_Not_Abstract()
        {
            typeof(UserFriendsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserFriendsRequest_Is_Sealed()
        {
            typeof(UserFriendsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserFriendsRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserFriendsRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUserFriend>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserFriendsRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserFriendsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserFriendsRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserFriendsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserFriendsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFriendsRequest();
            request.UriTemplate.Should().Be("users/{username}/friends{?extended}");
        }

        [Fact]
        public void Test_UserFriendsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserFriendsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserFriendsRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserFriendsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFriendsRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserFriendsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserFriendsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
