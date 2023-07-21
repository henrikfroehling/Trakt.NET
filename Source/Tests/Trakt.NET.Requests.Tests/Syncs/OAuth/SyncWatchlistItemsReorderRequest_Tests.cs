namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncWatchlistItemsReorderRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistItemsReorderRequest_Has_AuthorizationRequirement_Required()
        {
            var request = new SyncWatchlistItemsReorderRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.Required);
        }

        [Fact]
        public void Test_SyncWatchlistItemsReorderRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistItemsReorderRequest();
            request.UriTemplate.Should().Be("sync/watchlist/reorder");
        }
    }
}
