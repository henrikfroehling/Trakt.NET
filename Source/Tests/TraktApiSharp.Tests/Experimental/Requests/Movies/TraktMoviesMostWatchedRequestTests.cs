namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;

    [TestClass]
    public class TraktMoviesMostWatchedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsNotAbstract()
        {
            typeof(TraktMoviesMostWatchedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsSealed()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostWatchedRequestIsSubclassOfATraktMoviesMostPWCRequest()
        {
            typeof(TraktMoviesMostWatchedRequest).IsSubclassOf(typeof(ATraktMoviesMostPWCRequest<TraktMostWatchedMovie>)).Should().BeTrue();
        }
    }
}
