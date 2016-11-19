namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;

    [TestClass]
    public class TraktShowSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSummaryRequestIsNotAbstract()
        {
            typeof(TraktShowSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSummaryRequestIsSealed()
        {
            typeof(TraktShowSummaryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSummaryRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktShowSummaryRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktShow>)).Should().BeTrue();
        }
    }
}
