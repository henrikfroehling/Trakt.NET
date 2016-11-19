namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Get.Shows.Episodes;

    [TestClass]
    public class TraktEpisodeSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsNotAbstract()
        {
            typeof(TraktEpisodeSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsSealed()
        {
            typeof(TraktEpisodeSummaryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeSummaryRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }
    }
}
