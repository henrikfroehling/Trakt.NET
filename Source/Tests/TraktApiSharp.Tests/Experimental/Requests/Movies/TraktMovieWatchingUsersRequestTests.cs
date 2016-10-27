namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMovieWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktMovieWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestIsSealed()
        {
            typeof(TraktMovieWatchingUsersRequest).IsSealed.Should().BeTrue();
        }
    }
}
