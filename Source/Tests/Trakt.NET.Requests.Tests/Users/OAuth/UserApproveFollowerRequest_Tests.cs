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
    public class UserApproveFollowerRequest_Tests
    {
        [Fact]
        public void Test_UserApproveFollowerRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserApproveFollowerRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new UserApproveFollowerRequest();
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Object);
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Has_Valid_UriTemplate()
        {
            var request = new UserApproveFollowerRequest();
            request.UriTemplate.Should().Be("users/requests/{id}");
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Returns_Valid_UriPathParameters()
        {
            var request = new UserApproveFollowerRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new UserApproveFollowerRequest();

            Action act = () => request.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            request = new UserApproveFollowerRequest { Id = string.Empty };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            request = new UserApproveFollowerRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
