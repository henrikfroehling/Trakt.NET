namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserStatisticsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserStatisticsRequestIsNotAbstract()
        {
            typeof(TraktUserStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserStatisticsRequestIsSealed()
        {
            typeof(TraktUserStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserStatisticsRequestIsSubclassOfATraktUsersSingleItemGetRequest()
        {
            typeof(TraktUserStatisticsRequest).IsSubclassOf(typeof(ATraktUsersSingleItemGetRequest<TraktUserStatistics>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserStatisticsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserStatisticsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }
    }
}
