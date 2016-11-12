namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;

    [TestClass]
    public class TraktShowsMostWatchedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostWatchedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostWatchedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostWatchedRequestIsSealed()
        {
            typeof(TraktShowsMostWatchedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostWatchedRequestIsSubclassOfATraktShowsMostPWCRequest()
        {
            typeof(TraktShowsMostWatchedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostWatchedShow>)).Should().BeTrue();
        }
    }
}
