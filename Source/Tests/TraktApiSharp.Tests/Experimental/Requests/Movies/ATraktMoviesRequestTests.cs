namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class ATraktMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesRequestIsAbstract()
        {
            typeof(ATraktMoviesRequest).IsAbstract.Should().BeTrue();
        }
    }
}
