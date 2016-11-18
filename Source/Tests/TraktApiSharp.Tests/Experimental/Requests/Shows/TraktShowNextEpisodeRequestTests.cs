namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowNextEpisodeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowNextEpisodeRequestIsNotAbstract()
        {
            typeof(TraktShowNextEpisodeRequest).IsAbstract.Should().BeFalse();
        }
    }
}
