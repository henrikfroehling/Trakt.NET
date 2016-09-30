namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Search;

    [TestClass]
    public class TraktSearchIdLookupRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestIsNotAbstract()
        {
            typeof(TraktSearchIdLookupRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestIsSealed()
        {
            typeof(TraktSearchIdLookupRequest).IsSealed.Should().BeTrue();
        }
    }
}
