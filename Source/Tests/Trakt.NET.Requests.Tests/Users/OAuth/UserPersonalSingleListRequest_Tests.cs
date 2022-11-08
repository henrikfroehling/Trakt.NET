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
    public class UserPersonalSingleListRequest_Tests
    {
        [Fact]
        public void Test_UserPersonalSingleListRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserPersonalSingleListRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Optional);
        }

        [Fact]
        public void Test_UserPersonalSingleListRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserPersonalSingleListRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_UserPersonalSingleListRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPersonalSingleListRequest();
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [Fact]
        public void Test_UserPersonalSingleListRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserPersonalSingleListRequest { Username = "username", Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["username"] = "username",
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserPersonalSingleListRequest_Validate_Throws_Exceptions()
        {
            // username is null
            var request = new UserPersonalSingleListRequest { Id = "123" };

            Action act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty username
            request = new UserPersonalSingleListRequest { Username = string.Empty, Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // username with spaces
            request = new UserPersonalSingleListRequest { Username = "invalid username", Id = "123" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id is null
            request = new UserPersonalSingleListRequest { Username = "username" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            request = new UserPersonalSingleListRequest { Username = "username", Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            request = new UserPersonalSingleListRequest { Username = "username", Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
