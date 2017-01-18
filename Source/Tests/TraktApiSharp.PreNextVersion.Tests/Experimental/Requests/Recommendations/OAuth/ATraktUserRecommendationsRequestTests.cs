namespace TraktApiSharp.Tests.Experimental.Requests.Recommendations.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth")]
        public void TestATraktUserRecommendationsRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(ATraktUserRecommendationsRequest<int>).IsSubclassOf(typeof(ATraktPaginationGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Recommendations"), TestCategory("With OAuth")]
        public void TestATraktUserRecommendationsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktUserRecommendationsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
