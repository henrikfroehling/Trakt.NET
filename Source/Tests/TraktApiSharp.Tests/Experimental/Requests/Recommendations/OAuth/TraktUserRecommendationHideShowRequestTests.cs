namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;

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
    }
}
