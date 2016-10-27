namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMovieRelatedMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestIsNotAbstract()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieRelatedMoviesRequestIsSealed()
        {
            typeof(TraktMovieRelatedMoviesRequest).IsSealed.Should().BeTrue();
        }
    }
}
