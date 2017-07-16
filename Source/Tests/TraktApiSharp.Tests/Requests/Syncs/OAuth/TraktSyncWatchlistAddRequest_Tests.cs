namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses.Implementations;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncWatchlistAddRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncWatchlistAddRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncWatchlistAddRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncWatchlistAddRequest_Is_Sealed()
        {
            typeof(TraktSyncWatchlistAddRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistAddRequest_Inherits_ATraktSyncPostRequest_2()
        {
            typeof(TraktSyncWatchlistAddRequest).IsSubclassOf(typeof(ATraktSyncPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncWatchlistAddRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncWatchlistAddRequest();
            request.UriTemplate.Should().Be("sync/watchlist");
        }
    }
}
