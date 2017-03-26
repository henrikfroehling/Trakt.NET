namespace TraktApiSharp.Tests.Requests.Users.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Users.OAuth;
    using Xunit;

    [Category("Requests.Users.OAuth")]
    public class TraktUserFollowRequestsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Is_Not_Abstract()
        {
            typeof(TraktUserFollowRequestsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Is_Sealed()
        {
            typeof(TraktUserFollowRequestsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Inherits_ATraktUsersGetRequest_1()
        {
            typeof(TraktUserFollowRequestsRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktUserFollowRequest>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserFollowRequestsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserFollowRequestsRequest();
            request.UriTemplate.Should().Be("users/requests{?extended}");
        }

        [Fact]
        public void Test_TraktUserFollowRequestsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new TraktUserFollowRequestsRequest();

            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new TraktUserFollowRequestsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
