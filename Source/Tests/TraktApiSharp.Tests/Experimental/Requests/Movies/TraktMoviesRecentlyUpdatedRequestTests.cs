namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMoviesRecentlyUpdatedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesRecentlyUpdatedRequestIsNotAbstract()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesRecentlyUpdatedRequestIsSealed()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsSealed.Should().BeTrue();
        }
    }
}
