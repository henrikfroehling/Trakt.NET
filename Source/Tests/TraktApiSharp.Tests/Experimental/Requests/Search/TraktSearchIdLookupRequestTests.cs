namespace TraktApiSharp.Tests.Experimental.Requests.Search
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
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

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSearchIdLookupRequest).GetMethods()
                                                               .Where(m => m.Name == "GetUriPathParameters")
                                                               .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestUriParamsWithoutIdType()
        {
            var request = new TraktSearchIdLookupRequest(null)
            {
                IdType = null
            };

            Action act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestUriParamsWithoutLookupId()
        {
            var request = new TraktSearchIdLookupRequest(null)
            {
                IdType = TraktSearchIdType.Trakt,
                LookupId = null
            };

            Action act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentException>();

            request = new TraktSearchIdLookupRequest(null)
            {
                IdType = TraktSearchIdType.Trakt,
                LookupId = string.Empty
            };

            act = () => request.GetUriPathParameters();
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Search"), TestCategory("Without OAuth"), TestCategory("Search Id Lookup")]
        public void TestTraktSearchIdLookupRequestUriParamsWithResultTypes()
        {
            var idType = TraktSearchIdType.Trakt;
            var lookupId = "2";
            var resultTypes = TraktSearchResultType.Movie | TraktSearchResultType.Show;

            var request = new TraktSearchIdLookupRequest(null)
            {
                IdType = idType,
                LookupId = lookupId,
                ResultTypes = resultTypes
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);
            uriParams.Should().Contain(new Dictionary<string, object>
            {
                ["id_type"] = idType.UriName,
                ["id"] = lookupId,
                ["type"] = resultTypes.UriName
            });
        }
    }
}
