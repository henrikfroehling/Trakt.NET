namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;

    [TestClass]
    public class TraktUserShowRecommendationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth"), TestCategory("Shows")]
        public void TestTraktUserShowRecommendationsRequestIsNotAbstract()
        {
            typeof(TraktUserShowRecommendationsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
