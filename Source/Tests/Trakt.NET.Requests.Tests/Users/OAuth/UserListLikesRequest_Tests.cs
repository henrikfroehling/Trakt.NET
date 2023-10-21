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
    public class UserListLikesRequest_Tests
    {
        [Fact]
        public void Test_UserListLikesRequest_Has_AuthorizationRequirement_OptionalButMightBeRequired()
        {
            var request = new UserListLikesRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.OptionalButMightBeRequired);
        }

        [Fact]
        public void Test_UserListLikesRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListLikesRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{list_id}/likes{?page,limit}");
        }

        [Fact]
        public void Test_UserListLikesRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserListLikesRequest { Username = "username", ListId = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["list_id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserListLikesRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserListLikesRequest { ListId = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserListLikesRequest { Username = string.Empty, ListId = "123" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserListLikesRequest { Username = "invalid username", ListId = "123" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // list id is null
            request = new UserListLikesRequest { Username = "username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty list id
            request = new UserListLikesRequest { Username = "username", ListId = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // list id with spaces
            request = new UserListLikesRequest { Username = "username", ListId = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
