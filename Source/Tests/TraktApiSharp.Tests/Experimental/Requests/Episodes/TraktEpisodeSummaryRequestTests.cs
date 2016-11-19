namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Episodes;

    [TestClass]
    public class TraktEpisodeSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeSummaryRequestIsNotAbstract()
        {
            typeof(TraktEpisodeSummaryRequest).IsAbstract.Should().BeFalse();
        }
    }
}
