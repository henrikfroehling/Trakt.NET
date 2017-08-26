namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class TraktUserShowRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_IsNotAbstract()
        {
            typeof(TraktUserShowRecommendationsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_IsSealed()
        {
            typeof(TraktUserShowRecommendationsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_Inherits_ATraktUserRecommendationsRequest_1()
        {
            typeof(TraktUserShowRecommendationsRequest).IsSubclassOf(typeof(ATraktUserRecommendationsRequest<ITraktShow>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserShowRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserShowRecommendationsRequest();
            request.UriTemplate.Should().Be("recommendations/shows{?extended,limit}");
        }

        [Fact]
        public void Test_TraktUserShowRecommendationsRequest_Returns_Valid_UriPathParameters()
        {
            // no parameters
            var requestMock = new TraktUserShowRecommendationsRequest();

            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktUserShowRecommendationsRequest { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });

            // with extended info and limit
            var limit = 123U;
            requestMock = new TraktUserShowRecommendationsRequest { ExtendedInfo = extendedInfo, Limit = limit };

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
