namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncWatchlistRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchlistRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsSealed()
        {
            typeof(TraktSyncWatchlistRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestIsSubclassOfATraktSyncPaginationGetRequest()
        {
            typeof(TraktSyncWatchlistRequest).IsSubclassOf(typeof(ATraktSyncPaginationGetRequest<TraktWatchlistItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncWatchlistRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchlistRequest(null);
            request.UriTemplate.Should().Be("sync/watchlist{/type}{?extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktSyncWatchlistRequest).GetMethods()
                                                              .Where(m => m.Name == "GetUriPathParameters")
                                                              .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestUriParamsWithoutType()
        {
            var request = new TraktSyncWatchlistRequest(null);
            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestUriParamsWithUnspecifiedType()
        {
            var type = TraktSyncItemType.Unspecified;

            var request = new TraktSyncWatchlistRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();
            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchlistRequestUriParamsWithType()
        {
            var type = TraktSyncItemType.Episode;

            var request = new TraktSyncWatchlistRequest(null)
            {
                Type = type
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("type", type.UriName);
        }
    }
}
