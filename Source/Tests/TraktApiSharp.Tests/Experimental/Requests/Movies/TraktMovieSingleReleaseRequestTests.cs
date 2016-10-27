namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMovieSingleReleaseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestIsNotAbstract()
        {
            typeof(TraktMovieSingleReleaseRequest).IsAbstract.Should().BeFalse();
        }
    }
}
