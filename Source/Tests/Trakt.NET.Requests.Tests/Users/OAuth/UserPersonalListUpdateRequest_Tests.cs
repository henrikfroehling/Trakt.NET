namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserPersonalListUpdateRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalListUpdateRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPersonalListUpdateRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPersonalListUpdateRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserPersonalListUpdateRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserPersonalListUpdateRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalListUpdateRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [Fact]
        public void Test_UserPersonalListUpdateRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalListUpdateRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalListUpdateRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserPersonalListUpdateRequest { Id = "123", RequestBody = new TraktUserPersonalListPost() };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalListUpdateRequest { Username = string.Empty, Id = "123", RequestBody = new TraktUserPersonalListPost() };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalListUpdateRequest { Username = "invalid username", Id = "123", RequestBody = new TraktUserPersonalListPost() };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id is null
            request = new UserPersonalListUpdateRequest { Username = "username", RequestBody = new TraktUserPersonalListPost() };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new UserPersonalListUpdateRequest { Username = "username", Id = string.Empty, RequestBody = new TraktUserPersonalListPost() };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new UserPersonalListUpdateRequest { Username = "username", Id = "invalid id", RequestBody = new TraktUserPersonalListPost() };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
