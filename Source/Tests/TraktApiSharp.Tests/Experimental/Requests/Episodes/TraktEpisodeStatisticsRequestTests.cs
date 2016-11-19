namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Episodes;

    [TestClass]
    public class TraktEpisodeStatisticsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeStatisticsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeStatisticsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
