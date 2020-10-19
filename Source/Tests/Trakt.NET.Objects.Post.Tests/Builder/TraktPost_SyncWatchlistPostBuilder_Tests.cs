namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder.Interfaces;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncWatchlistPostBuilder()
        {
            ITraktSyncWatchlistPostBuilder syncCollectionPostBuilder = TraktPost.NewSyncWatchlistPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_Empty_Build()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost().Build();
            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
