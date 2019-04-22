namespace TraktNet.Requests.Tests.Recommendations.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class UserShowRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_UserShowRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new UserShowRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_UserShowRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new UserShowRecommendationsRequest();
            request.UriTemplate.Should().Be("recommendations/shows{?extended,limit}");
        }

        [Fact]
        public void Test_UserShowRecommendationsRequest_Returns_Valid_UriPathParameters()
        {
            // no parameters
            var requestMock = new UserShowRecommendationsRequest();

            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new UserShowRecommendationsRequest { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });

            // with extended info and limit
            var limit = 123U;
            requestMock = new UserShowRecommendationsRequest { ExtendedInfo = extendedInfo, Limit = limit };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(2)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString(),
                                                           ["limit"] = limit.ToString()
                                                       });
        }
    }
}
