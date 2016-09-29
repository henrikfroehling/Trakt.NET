namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserRecommendationHideMovieRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestIsNotAbstract()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestIsSealed()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestIsSubclassOfATraktNoContentDeleteByIdRequest()
        {
            typeof(TraktUserRecommendationHideMovieRequest).IsSubclassOf(typeof(ATraktNoContentDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktUserRecommendationHideMovieRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestHasValidRequestObjectType()
        {
            var request = new TraktUserRecommendationHideMovieRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Movies);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserRecommendationHideMovieRequestHasValidUriTemplate()
        {
            var request = new TraktUserRecommendationHideMovieRequest(null);
            request.UriTemplate.Should().Be("recommendations/movies/{id}");
        }
    }
}
