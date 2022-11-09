namespace TraktNet.Requests.Tests.Users.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Parameters;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Users.OAuth;
    using Xunit;

    [TestCategory("Requests.Users.OAuth")]
    public class UserPendingFollowingRequestsRequest_Tests
    {
        [Fact]
        public void Test_UserPendingFollowingRequestsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserPendingFollowingRequestsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserPendingFollowingRequestsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserPendingFollowingRequestsRequest();
            request.UriTemplate.Should().Be("users/requests/following{?extended}");
        }

        [Fact]
        public void Test_UserPendingFollowingRequestsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new UserPendingFollowingRequestsRequest();

            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new UserPendingFollowingRequestsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
