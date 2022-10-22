namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncWatchlistRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostSeason postSeason = syncWatchlistRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostSeason postSeason1 = syncWatchlistRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            ITraktSyncWatchlistPostSeason postSeason2 = syncWatchlistRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Episodes.Should().BeNull();
        }
    }
}
