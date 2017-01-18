namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserShowRecommendationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestIsNotAbstract()
        {
            typeof(TraktUserShowRecommendationsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestIsSealed()
        {
            typeof(TraktUserShowRecommendationsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestIsSubclassOfATraktUserRecommendationsRequest()
        {
            typeof(TraktUserShowRecommendationsRequest).IsSubclassOf(typeof(ATraktUserRecommendationsRequest<TraktShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestHasAuthorizationRequired()
        {
            var request = new TraktUserShowRecommendationsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestHasValidUriTemplate()
        {
            var request = new TraktUserShowRecommendationsRequest(null);
            request.UriTemplate.Should().Be("recommendations/shows{?extended,limit}");
        }
    }
}
