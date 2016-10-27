namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMoviesMostCollectedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestTraktMoviesMostCollectedRequestIsNotAbstract()
        {
            typeof(TraktMoviesMostCollectedRequest).IsAbstract.Should().BeFalse();
        }
    }
}
