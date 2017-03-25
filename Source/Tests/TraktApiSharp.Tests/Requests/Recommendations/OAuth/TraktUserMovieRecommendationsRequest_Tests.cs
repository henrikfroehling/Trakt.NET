namespace TraktApiSharp.Tests.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Requests.Recommendations.OAuth;
    using Xunit;

    [Category("Requests.Recommendations.OAuth")]
    public class TraktUserMovieRecommendationsRequest_Tests
    {
        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_IsNotAbstract()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_IsSealed()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_Inherits_ATraktUserRecommendationsRequest_1()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsSubclassOf(typeof(ATraktUserRecommendationsRequest<TraktMovie>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new TraktUserMovieRecommendationsRequest();
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktUserMovieRecommendationsRequest();
            request.UriTemplate.Should().Be("recommendations/movies{?extended,limit}");
        }

        [Fact]
        public void Test_TraktUserMovieRecommendationsRequest_Returns_Valid_UriPathParameters()
        {
            // no parameters
            var requestMock = new TraktUserMovieRecommendationsRequest();

            requestMock.GetUriPathParameters().Should().NotBeNull().And.BeEmpty().And.HaveCount(0);

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            requestMock = new TraktUserMovieRecommendationsRequest { ExtendedInfo = extendedInfo };

            requestMock.GetUriPathParameters().Should().NotBeNull()
                                                       .And.HaveCount(1)
                                                       .And.Contain(new Dictionary<string, object>
                                                       {
                                                           ["extended"] = extendedInfo.ToString()
                                                       });

            // with extended info and limit
            var limit = 123U;
            requestMock = new TraktUserMovieRecommendationsRequest { ExtendedInfo = extendedInfo, Limit = limit };

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
