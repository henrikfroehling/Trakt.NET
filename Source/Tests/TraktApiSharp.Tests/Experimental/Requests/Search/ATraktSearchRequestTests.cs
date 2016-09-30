namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Search;
    using TraktApiSharp.Objects.Basic;

    [TestClass]
    public class ATraktSearchRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth")]
        public void TestATraktSearchRequestIsAbstract()
        {
            typeof(ATraktSearchRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth")]
        public void TestATraktSearchRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(ATraktSearchRequest).IsSubclassOf(typeof(ATraktPaginationGetRequest<TraktSearchResult>)).Should().BeTrue();
        }
    }
}
