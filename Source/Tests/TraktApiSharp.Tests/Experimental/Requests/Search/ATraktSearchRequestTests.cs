namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Search;

    [TestClass]
    public class ATraktSearchRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth")]
        public void TestATraktSearchRequestIsAbstract()
        {
            typeof(ATraktSearchRequest).IsAbstract.Should().BeTrue();
        }
    }
}
