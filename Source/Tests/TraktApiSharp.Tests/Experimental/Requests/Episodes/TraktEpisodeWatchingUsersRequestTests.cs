namespace TraktApiSharp.Tests.Experimental.Requests.Episodes
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Episodes;

    [TestClass]
    public class TraktEpisodeWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Episodes")]
        public void TestTraktEpisodeWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktEpisodeWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }
    }
}
