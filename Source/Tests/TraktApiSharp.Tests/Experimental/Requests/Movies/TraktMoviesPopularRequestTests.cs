namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;

    [TestClass]
    public class TraktMoviesPopularRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesPopularRequestIsNotAbstract()
        {
            typeof(TraktMoviesPopularRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesPopularRequestIsSealed()
        {
            typeof(TraktMoviesPopularRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesPopularRequestIsSubclassOfATraktMoviesRequest()
        {
            typeof(TraktMoviesPopularRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktMovie>)).Should().BeTrue();
        }
    }
}
