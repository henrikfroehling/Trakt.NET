namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class ATraktMoviesMostPWCRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesMostPWCRequestIsAbstract()
        {
            typeof(ATraktMoviesMostPWCRequest).IsAbstract.Should().BeTrue();
        }
    }
}
