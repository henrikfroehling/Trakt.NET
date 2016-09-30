namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestHasQueryProperty()
        {
            var startDatePropertyInfo = typeof(TraktSearchTextQueryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Query")
                    .FirstOrDefault();

            startDatePropertyInfo.CanRead.Should().BeTrue();
            startDatePropertyInfo.CanWrite.Should().BeTrue();
            startDatePropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSearchTextQueryRequest).GetMethods()
                                                                .Where(m => m.Name == "GetUriPathParameters")
                                                                .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestUriParamsWithoutResultTypes()
        {
            var request = new TraktSearchTextQueryRequest(null)
            {
                ResultTypes = null
            };

            Action act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Text Query")]
        public void TestTraktSearchTextQueryRequestUriParamsWithoutQuery()
        {
            var request = new TraktSearchTextQueryRequest(null)
            {
                ResultTypes = TraktSearchResultType.Movie,
                Query = null
            };

            Action act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentException>();

            request = new TraktSearchTextQueryRequest(null)
            {
                ResultTypes = TraktSearchResultType.Movie,
                Query = string.Empty
            };

            act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Calendars"), TestCategory("Without OAuth"), TestCategory("Movies")]
        public void TestTraktSearchTextQueryRequestUriParamsWithSearchFields()
        {
            var resultTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;
            var query = "the big bang theory";
            var fields = TraktSearchField.Name | TraktSearchField.Overview;

            var request = new TraktSearchTextQueryRequest(null)
            {
                ResultTypes = resultTypes,
                Query = query,
                SearchFields = fields
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["type"] = resultTypes.UriName,
                ["query"] = query,
                ["fields"] = fields.UriName
            });
        }
    }
}
