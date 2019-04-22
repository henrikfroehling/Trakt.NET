namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserUnfollowUserRequest_Tests
    {
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
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserUnfollowUserRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserUnfollowUserRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
