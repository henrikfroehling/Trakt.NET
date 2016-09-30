namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Search;

    [TestClass]
    public class TraktSearchTextQueryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestIsNotAbstract()
        {
            typeof(TraktSearchTextQueryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestIsSealed()
        {
            typeof(TraktSearchTextQueryRequest).IsSealed.Should().BeTrue();
        }
    }
}
