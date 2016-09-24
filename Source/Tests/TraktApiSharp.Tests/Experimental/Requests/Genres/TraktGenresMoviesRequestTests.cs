namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Genres;

    [TestClass]
    public class TraktGenresMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestIsNotAbstract()
        {
            typeof(TraktGenresMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Movies")]
        public void TestTraktGenresMoviesRequestIsSealed()
        {
            typeof(TraktGenresMoviesRequest).IsSealed.Should().BeTrue();
        }
    }
}
