namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Episodes;

    [TestClass]
    public class TraktEpisodeRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeRatingsRequestIsNotAbstract()
        {
            typeof(TraktEpisodeRatingsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
