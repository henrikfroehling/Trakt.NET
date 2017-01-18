namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserMovieRecommendationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestIsNotAbstract()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestIsSealed()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestIsSubclassOfATraktUserRecommendationsRequest()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsSubclassOf(typeof(ATraktUserRecommendationsRequest<TraktMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestHasAuthorizationRequired()
        {
            var request = new TraktUserMovieRecommendationsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestHasValidUriTemplate()
        {
            var request = new TraktUserMovieRecommendationsRequest(null);
            request.UriTemplate.Should().Be("recommendations/movies{?extended,limit}");
        }
    }
}
