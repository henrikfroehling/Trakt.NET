namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Search;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestIsSubclassOfATraktSearchRequest()
        {
            typeof(TraktSearchIdLookupRequest).IsSubclassOf(typeof(ATraktSearchRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSearchIdLookupRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }
    }
}
