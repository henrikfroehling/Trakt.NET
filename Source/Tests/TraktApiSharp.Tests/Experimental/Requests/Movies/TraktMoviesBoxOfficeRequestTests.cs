namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMoviesBoxOfficeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestIsNotAbstract()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesBoxOfficeRequestIsSealed()
        {
            typeof(TraktMoviesBoxOfficeRequest).IsSealed.Should().BeTrue();
        }
    }
}
