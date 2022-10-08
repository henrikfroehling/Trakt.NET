namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_ITraktSeason()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_ITraktSeasonIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_WatchedSeason()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(new WatchedSeason(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_WatchedSeasonIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(new WatchedSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostSeason postSeason = syncHistoryPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostSeason postSeason1 = syncHistoryPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostSeason postSeason2 = syncHistoryPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostSeason postSeason1 = syncHistoryPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostSeason postSeason2 = syncHistoryPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonsWatchedAt_WatchedSeason()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonsWatchedAt(new List<WatchedSeason>
                {
                    new WatchedSeason(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedSeason(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostSeason postSeason1 = syncHistoryPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);
            postSeason1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostSeason postSeason2 = syncHistoryPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);
            postSeason2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonsWatchedAt_WatchedSeasonIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithSeasonsWatchedAt(new List<WatchedSeasonIds>
                {
                    new WatchedSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedSeasonIds(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostSeason postSeason1 = syncHistoryPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);
            postSeason1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostSeason postSeason2 = syncHistoryPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);
            postSeason2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }
    }
}
