namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Episodes;
    using TraktApiSharp.Objects.Basic;

    [TestClass]
    public class TraktEpisodeStatisticsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeStatisticsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsSealed()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktEpisodeStatisticsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktStatistics>)).Should().BeTrue();
        }
    }
}
