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
    public class UserApproveFollowerRequest_Tests
    {
        [Fact]
        public void Test_UserApproveFollowerRequest_Is_Not_Abstract()
        {
            typeof(UserApproveFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Is_Sealed()
        {
            typeof(UserApproveFollowerRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Inherits_ABodylessPostRequest_1()
        {
            typeof(UserApproveFollowerRequest).IsSubclassOf(typeof(ABodylessPostRequest<ITraktUserFollower>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserApproveFollowerRequest_Implements_IHasId_Interface()
        {
            typeof(UserApproveFollowerRequest).GetInterfaces().Should().Contain(typeof(IHasId));
        }

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
            requestMock.RequestObjectType.Should().Be(RequestObjectType.Unspecified);
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
            act.ShouldThrow<ArgumentNullException>();

            // empty id
            request = new UserApproveFollowerRequest { Id = string.Empty };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();

            // id with spaces
            request = new UserApproveFollowerRequest { Id = "invalid id" };

            act = () => request.Validate();
            act.ShouldThrow<ArgumentException>();
        }
    }
}
