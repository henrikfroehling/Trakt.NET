namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserWatchedHistoryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestIsNotAbstract()
        {
            typeof(TraktUserWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedHistoryRequestIsSealed()
        {
            typeof(TraktUserWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }
    }
}
