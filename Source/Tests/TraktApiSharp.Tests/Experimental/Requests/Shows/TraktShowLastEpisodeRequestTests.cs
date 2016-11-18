namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowLastEpisodeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowLastEpisodeRequestIsNotAbstract()
        {
            typeof(TraktShowLastEpisodeRequest).IsAbstract.Should().BeFalse();
        }
    }
}
