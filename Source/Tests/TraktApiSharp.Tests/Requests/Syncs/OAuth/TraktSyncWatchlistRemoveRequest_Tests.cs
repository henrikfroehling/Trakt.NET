namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchlistRemoveRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistRemoveRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchlistRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRemoveRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchlistRemoveRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRemoveRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncWatchlistRemoveRequest).IsSubclassOf(typeof(ASyncPostRequest<ITraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistRemoveRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchlistRemoveRequest();
            request.UriTemplate.Should().Be("sync/watchlist/remove");
        }
    }
}
