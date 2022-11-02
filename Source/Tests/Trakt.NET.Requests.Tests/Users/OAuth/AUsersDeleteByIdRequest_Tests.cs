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
    public class AUsersDeleteByIdRequest_Tests
    {
        internal class UsersDeleteByIdRequestMock : AUsersDeleteByIdRequest
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }
            public override RequestObjectType RequestObjectType { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_AUsersDeleteByIdRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UsersDeleteByIdRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_AUsersDeleteByIdRequest_Returns_Valid_UriPathParameters()
        {
            var requestMock = new UsersDeleteByIdRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AUsersDeleteByIdRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new UsersDeleteByIdRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // empty id
            requestMock = new UsersDeleteByIdRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();

            // id with spaces
            requestMock = new UsersDeleteByIdRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<TraktRequestValidationException>();
        }
    }
}
