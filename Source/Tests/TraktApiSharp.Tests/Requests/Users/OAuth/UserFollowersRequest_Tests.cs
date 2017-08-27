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
    public class UserFollowersRequest_Tests
    {
        [Fact]
        public void Test_UserFollowersRequest_Is_Not_Abstract()
        {
            typeof(UserFollowersRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserFollowersRequest_Is_Sealed()
        {
            typeof(UserFollowersRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowersRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserFollowersRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowersRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserFollowersRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserFollowersRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserFollowersRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserFollowersRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFollowersRequest();
            request.UriTemplate.Should().Be("users/{username}/followers{?extended}");
        }

        [Fact]
        public void Test_UserFollowersRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserFollowersRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserFollowersRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserFollowersRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFollowersRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserFollowersRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserFollowersRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
