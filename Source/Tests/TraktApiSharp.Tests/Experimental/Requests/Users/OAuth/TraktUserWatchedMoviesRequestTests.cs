namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserWatchedMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestIsNotAbstract()
        {
            typeof(TraktUserWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestIsSealed()
        {
            typeof(TraktUserWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }
    }
}
