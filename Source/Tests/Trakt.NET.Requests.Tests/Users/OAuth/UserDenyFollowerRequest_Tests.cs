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
    public class UserDenyFollowerRequest_Tests
    {
        [Fact]
        public void Test_UserDenyFollowerRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new UserDenyFollowerRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserDenyFollowerRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserDenyFollowerRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Unspecified);
        }

        [Fact]
        public void Test_UserDenyFollowerRequest_Has_Valid_UriTemplate()
        {
            var request = new UserDenyFollowerRequest();
            request.UriTemplate.Should().Be("users/requests/{id}");
        }

        [Fact]
        public void Test_UserDenyFollowerRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserDenyFollowerRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserDenyFollowerRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new UserDenyFollowerRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserDenyFollowerRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserDenyFollowerRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
