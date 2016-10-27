namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMoviePeopleRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMoviePeopleRequestIsNotAbstract()
        {
            typeof(TraktMoviePeopleRequest).IsAbstract.Should().BeFalse();
        }
    }
}
