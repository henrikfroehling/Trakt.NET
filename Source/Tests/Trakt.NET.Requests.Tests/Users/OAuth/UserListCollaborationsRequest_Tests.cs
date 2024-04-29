namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserListCollaborationsRequest_Tests
    {
        [Fact]
        public void Test_UserListCollaborationsRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserListCollaborationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserListCollaborationsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListCollaborationsRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/collaborations");
        }

        [Fact]
        public void Test_UserListCollaborationsRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserListCollaborationsRequest { Username = "username" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                   });
        }

        [Fact]
        public void Test_UserListCollaborationsRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserListCollaborationsRequest();

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserListCollaborationsRequest { Username = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserListCollaborationsRequest { Username = "invalid username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
