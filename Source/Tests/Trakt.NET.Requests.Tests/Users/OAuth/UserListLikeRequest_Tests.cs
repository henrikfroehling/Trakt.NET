namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserListLikeRequest_Tests
    {
        [Fact]
        public void Test_UserListLikeRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserListLikeRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserListLikeRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserListLikeRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserListLikeRequest_Has_Valid_UriTemplate()
        {
            var request = new UserListLikeRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [Fact]
        public void Test_UserListLikeRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserListLikeRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserListLikeRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserListLikeRequest { Id = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty username
            request = new UserListLikeRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // username with spaces
            request = new UserListLikeRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id is null
            request = new UserListLikeRequest { Username = "username" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserListLikeRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserListLikeRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
