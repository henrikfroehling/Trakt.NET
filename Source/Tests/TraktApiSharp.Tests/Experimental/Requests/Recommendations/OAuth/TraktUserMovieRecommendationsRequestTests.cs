namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;

    [TestClass]
    public class TraktUserMovieRecommendationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequestIsNotAbstract()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Movies")]
        public void TestTraktUserMovieRecommendationsRequesttIsSealed()
        {
            typeof(TraktUserMovieRecommendationsRequest).IsSealed.Should().BeTrue();
        }
    }
}
