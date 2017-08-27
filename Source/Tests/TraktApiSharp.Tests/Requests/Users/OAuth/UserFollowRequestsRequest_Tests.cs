namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class UserFollowRequestsRequest_Tests
    {
        [Fact]
        public void Test_UserFollowRequestsRequest_Is_Not_Abstract()
        {
            typeof(UserFollowRequestsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_UserFollowRequestsRequest_Is_Sealed()
        {
            typeof(UserFollowRequestsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowRequestsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(UserFollowRequestsRequest).IsSubclassOf(typeof(AUsersGetRequest<ITraktUserFollowRequest>)).Should().BeTrue();
        }

        [Fact]
        public void Test_UserFollowRequestsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserFollowRequestsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserFollowRequestsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserFollowRequestsRequest();
            request.UriTemplate.Should().Be("users/requests{?extended}");
        }

        [Fact]
        public void Test_UserFollowRequestsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserFollowRequestsRequest();

            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserFollowRequestsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
