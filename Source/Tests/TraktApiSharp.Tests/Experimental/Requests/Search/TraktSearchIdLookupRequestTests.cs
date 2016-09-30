namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestHasValidUriTemplate()
        {
            var request = new TraktSearchIdLookupRequest(null);
            request.UriTemplate.Should().Be("search/{id_type}/{id}{?type,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestHasIdTypeProperty()
        {
            var startDatePropertyInfo = typeof(TraktSearchIdLookupRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "IdType")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(TraktSearchIdType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestHasLookupIdProperty()
        {
            var startDatePropertyInfo = typeof(TraktSearchIdLookupRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LookupId")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
