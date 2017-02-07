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
    public class ATraktUsersPostByIdRequest_1_Tests
    {
        internal class TraktUsersPostByIdRequestMock : ATraktUsersPostByIdRequest<int, float>
        {
            public override string UriTemplate { get { throw new NotImplementedException(); } }

            public override TraktRequestObjectType RequestObjectType { get { throw new NotImplementedException(); } }
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Is_Abstract()
        {
            typeof(ATraktUsersPostByIdRequest<,>).IsAbstract.Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Has_GenericTypeParameter()
        {
            typeof(ATraktUsersPostByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUsersPostByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Inherits_ATraktPostRequest_2()
        {
            typeof(ATraktUsersPostByIdRequest<int, float>).IsSubclassOf(typeof(ATraktPostRequest<int, float>)).Should().BeTrue();
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Implements_ITraktHasId_Interface()
        {
            typeof(ATraktUsersPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUsersPostByIdRequestMock();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Returns_Valid_UriPathParameters()
        {
            var requestMock = new TraktUsersPostByIdRequestMock { Id = "123" };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["id"] = "123"
                                                       });
        }

        [Fact]
        public void Test_ATraktUsersPostByIdRequest_1_Validate_Throws_Exceptions()
        {
            // id is null
            var requestMock = new TraktUsersPostByIdRequestMock();

            Action act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            requestMock = new TraktUsersPostByIdRequestMock { Id = string.Empty };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            requestMock = new TraktUsersPostByIdRequestMock { Id = "invalid id" };

            act = () => requestMock.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
