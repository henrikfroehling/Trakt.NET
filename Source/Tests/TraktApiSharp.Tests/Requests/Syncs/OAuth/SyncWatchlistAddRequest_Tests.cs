namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncWatchlistAddRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchlistAddRequest_Is_Not_Abstract()
        {
            typeof(SyncWatchlistAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncWatchlistAddRequest_Is_Sealed()
        {
            typeof(SyncWatchlistAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchlistAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(SyncWatchlistAddRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncWatchlistAddRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchlistAddRequest();
            request.UriTemplate.Should().Be("sync/watchlist");
        }
    }
}
