namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Genres;
    using TraktApiSharp.Objects.Basic;

    [TestClass]
    public class ATraktGenresRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres")]
        public void TestATraktGenresRequestIsAbstract()
        {
            typeof(ATraktGenresRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres")]
        public void TestATraktGenresRequestIsSubclassOfATraktListGetRequest()
        {
            typeof(ATraktGenresRequest).IsSubclassOf(typeof(ATraktListGetRequest<TraktGenre>)).Should().BeTrue();
        }
    }
}
