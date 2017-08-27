namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserUnfollowUserRequest_Tests
    {
        [Fact]
        public void Test_UserUnfollowUserRequest_Is_Not_Abstract()
        {
            typeof(UserUnfollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Is_Sealed()
        {
            typeof(UserUnfollowUserRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Inherits_ATraktDeleteRequest()
        {
            typeof(UserUnfollowUserRequest).IsSubclassOf(typeof(ADeleteRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Has_Username_Property()
        {
            var propertyInfo = typeof(UserUnfollowUserRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserUnfollowUserRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Has_Valid_UriTemplate()
        {
            var request = new UserUnfollowUserRequest();
            request.UriTemplate.Should().Be("users/{username}/follow");
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserUnfollowUserRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username"
                                                   });
        }

        [Fact]
        public void Test_UserUnfollowUserRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserUnfollowUserRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty username
            request = new UserUnfollowUserRequest { Username = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // username with spaces
            request = new UserUnfollowUserRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
