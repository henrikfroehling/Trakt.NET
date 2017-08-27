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
    public class UserFollowingRequest_Tests
    {
        [Fact]
        public void Test_UserFollowingRequest_Is_Not_Abstract()
        {
            typeof(UserFollowingRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserFollowingRequest_Is_Sealed()
        {
            typeof(UserFollowingRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowingRequest_Inherits_AUsersGetRequest_1()
        {
            typeof(UserFollowingRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowingRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserFollowingRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserFollowingRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserFollowingRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserFollowingRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFollowingRequest();
            request.UriTemplate.Should().Be("users/{username}/following{?extended}");
        }

        [Fact]
        public void Test_UserFollowingRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserFollowingRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserFollowingRequest { Username = "username", ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }

        [Fact]
        public void Test_UserFollowingRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserFollowingRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserFollowingRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserFollowingRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
