﻿namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserListUnlikeRequest_Tests
    {
        [Fact]
        public void Test_UserListUnlikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserListUnlikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserListUnlikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserListUnlikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserListUnlikeRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListUnlikeRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [Fact]
        public void Test_UserListUnlikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserListUnlikeRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserListUnlikeRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserListUnlikeRequest { Id = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserListUnlikeRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserListUnlikeRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id is null
            request = new UserListUnlikeRequest { Username = "username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserListUnlikeRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserListUnlikeRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
