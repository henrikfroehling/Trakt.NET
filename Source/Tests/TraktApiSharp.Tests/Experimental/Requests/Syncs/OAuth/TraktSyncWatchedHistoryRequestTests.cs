namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncWatchedHistoryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsNotAbstract()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsSealed()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestIsSubclassOfATraktSyncPaginationRequest()
        {
            typeof(TraktSyncWatchedHistoryRequest).IsSubclassOf(typeof(ATraktSyncPaginationRequest<TraktHistoryItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncWatchedHistoryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasValidUriTemplate()
        {
            var request = new TraktSyncWatchedHistoryRequest(null);
            request.UriTemplate.Should().Be("sync/history{/type}{/item_id}{?start_at,end_at,extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncWatchedHistoryRequestHasItemIdProperty()
        {
            var sortingPropertyInfo = typeof(TraktSyncWatchedHistoryRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "ItemId")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(uint?));
        }
    }
}
