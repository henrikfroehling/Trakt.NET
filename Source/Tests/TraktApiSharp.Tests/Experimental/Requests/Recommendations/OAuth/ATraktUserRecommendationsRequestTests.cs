namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Recommendations.OAuth;

    [TestClass]
    public class ATraktUserRecommendationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth")]
        public void TestATraktUserRecommendationsRequestIsAbstract()
        {
            typeof(ATraktUserRecommendationsRequest).IsAbstract.Should().BeTrue();
        }
    }
}
