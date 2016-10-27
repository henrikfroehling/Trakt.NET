namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesRecentlyUpdatedRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(TraktMoviesRecentlyUpdatedRequest).IsSubclassOf(typeof(ATraktPaginationGetRequest<TraktRecentlyUpdatedMovie>)).Should().BeTrue();
        }
    }
}
