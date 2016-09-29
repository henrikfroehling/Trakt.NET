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
            typeof(ATraktUserRecommendationsRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth")]
        public void TestATraktUserRecommendationsRequestHasGenericTypeParameter()
        {
            typeof(ATraktUserRecommendationsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktUserRecommendationsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }
    }
}
