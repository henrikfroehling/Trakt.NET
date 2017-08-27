namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchlistRemoveRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchlistRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Is_Sealed()
        {
            typeof(SyncWatchlistRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(SyncWatchlistRemoveRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchlistRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistRemoveRequest();
            request.UriTemplate.Should().Be("sync/watchlist/remove");
        }
    }
}
