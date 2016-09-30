namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Search;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestIsSubclassOfATraktSearchRequest()
        {
            typeof(TraktSearchTextQueryRequest).IsSubclassOf(typeof(ATraktSearchRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestImplementsITraktFilterableInterface()
        {
            typeof(TraktSearchTextQueryRequest).GetInterfaces().Should().Contain(typeof(ITraktFilterable));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSearchTextQueryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestHasValidUriTemplate()
        {
            var request = new TraktSearchTextQueryRequest(null);
            request.UriTemplate.Should().Be("search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestHasSearchFieldsProperty()
        {
            var startDatePropertyInfo = typeof(TraktSearchTextQueryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "SearchFields")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(TraktSearchField));
        }
    }
}
