namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserRecommendationHideShowRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestIsNotAbstract()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestIsSealed()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestIsSubclassOfATraktNoContentDeleteByIdRequest()
        {
            typeof(TraktUserRecommendationHideShowRequest).IsSubclassOf(typeof(ATraktNoContentDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktUserRecommendationHideShowRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestHasValidRequestObjectType()
        {
            var request = new TraktUserRecommendationHideShowRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Shows);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserRecommendationHideShowRequestHasValidUriTemplate()
        {
            var request = new TraktUserRecommendationHideShowRequest(null);
            request.UriTemplate.Should().Be("recommendations/shows/{id}");
        }
    }
}
