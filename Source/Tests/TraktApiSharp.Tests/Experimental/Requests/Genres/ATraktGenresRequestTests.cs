namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Genres;

    [TestClass]
    public class ATraktGenresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres")]
        public void TestATraktGenresRequestIsAbstract()
        {
            typeof(ATraktGenresRequest).IsAbstract.Should().BeTrue();
        }
    }
}
