namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth")]
        public void TestATraktSearchRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktSearchRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth")]
        public void TestATraktSearchRequestHasResultTypesProperty()
        {
            var startDatePropertyInfo = typeof(ATraktSearchRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ResultTypes")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(TraktSearchResultType));
        }
    }
}
