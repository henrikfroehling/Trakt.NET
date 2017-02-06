namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserDenyFollowerRequest_Tests
    {
        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Is_Not_Abstract()
        {
            typeof(TraktUserDenyFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Is_Sealed()
        {
            typeof(TraktUserDenyFollowerRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Inherits_ATraktUsersDeleteByIdRequest()
        {
            typeof(TraktUserDenyFollowerRequest).IsSubclassOf(typeof(ATraktUsersDeleteByIdRequest)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new TraktUserDenyFollowerRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserDenyFollowerRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Unspecified);
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserDenyFollowerRequest();
            request.UriTemplate.Should().Be("users/requests/{id}");
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserDenyFollowerRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserDenyFollowerRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktUserDenyFollowerRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserDenyFollowerRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserDenyFollowerRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
