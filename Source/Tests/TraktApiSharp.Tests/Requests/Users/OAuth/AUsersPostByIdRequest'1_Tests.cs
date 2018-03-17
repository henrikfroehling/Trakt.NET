namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class AUsersPostByIdRequest_1_Tests
    {
        internal class RequestBodyMock : IRequestBody
        {
            public string ToJson() => "";

            public void Validate()
            {
            }
        }

        internal class UsersPostByIdRequestMock : AUsersPostByIdRequest<int, RequestBodyMock>
        {
            public override string UriTemplate => "";

            public override RequestObjectType RequestObjectType => RequestObjectType.Comments;
        }

        [Fact]
        public void Test_AUsersPostByIdRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new UsersPostByIdRequestMock();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_AUsersPostByIdRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new UsersPostByIdRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_AUsersPostByIdRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new UsersPostByIdRequestMock();

            Action act = () => requestMock.Validate();
            act.Should().Throw<ArgumentNullException>();

            // empty id
            requestMock = new UsersPostByIdRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();

            // id with spaces
            requestMock = new UsersPostByIdRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.Should().Throw<ArgumentException>();
        }
    }
}
