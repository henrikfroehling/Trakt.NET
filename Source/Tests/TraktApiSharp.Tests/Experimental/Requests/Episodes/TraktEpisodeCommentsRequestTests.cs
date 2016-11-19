namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Episodes;

    [TestClass]
    public class TraktEpisodeCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeCommentsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeCommentsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
