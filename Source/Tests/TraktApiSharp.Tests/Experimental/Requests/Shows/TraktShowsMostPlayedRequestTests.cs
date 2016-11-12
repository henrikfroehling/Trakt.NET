namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;

    [TestClass]
    public class TraktShowsMostPlayedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostPlayedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsSealed()
        {
            typeof(TraktShowsMostPlayedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsSubclassOfATraktShowsMostPWCRequest()
        {
            typeof(TraktShowsMostPlayedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostPlayedShow>)).Should().BeTrue();
        }
    }
}
