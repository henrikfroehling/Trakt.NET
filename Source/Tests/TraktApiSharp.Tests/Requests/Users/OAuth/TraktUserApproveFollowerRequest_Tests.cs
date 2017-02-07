namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserApproveFollowerRequest_Tests
    {
        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Is_Not_Abstract()
        {
            typeof(TraktUserApproveFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Is_Sealed()
        {
            typeof(TraktUserApproveFollowerRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Inherits_ATraktBodylessPostRequest_1()
        {
            typeof(TraktUserApproveFollowerRequest).IsSubclassOf(typeof(ATraktBodylessPostRequest<TraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Implements_ITraktHasId_Interface()
        {
            typeof(TraktUserApproveFollowerRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserApproveFollowerRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Returns_Valid_RequestObjectType()
        {
            var requestMock = new TraktUserApproveFollowerRequest();
            requestMock.RequestObjectType.Should().Be(TraktRequestObjectType.Unspecified);
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserApproveFollowerRequest();
            request.UriTemplate.Should().Be("users/requests/{id}");
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Returns_Valid_UriPathParameters()
        {
            var request = new TraktUserApproveFollowerRequest { Id = "123" };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["id"] = "123"
                                                   });
        }

        [Fact]
        public void Test_TraktUserApproveFollowerRequest_Validate_Throws_Exceptions()
        {
            // id is null
            var request = new TraktUserApproveFollowerRequest();

            Action act = () => request.Validate();
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new TraktUserApproveFollowerRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new TraktUserApproveFollowerRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
