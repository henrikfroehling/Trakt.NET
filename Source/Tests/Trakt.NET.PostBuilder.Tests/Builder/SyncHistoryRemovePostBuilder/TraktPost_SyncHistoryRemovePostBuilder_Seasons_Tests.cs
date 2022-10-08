namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostSeason postSeason = syncHistoryRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostSeason postSeason = syncHistoryRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostSeason postSeason1 = syncHistoryRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            ITraktSyncHistoryRemovePostSeason postSeason2 = syncHistoryRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostSeason postSeason1 = syncHistoryRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            ITraktSyncHistoryRemovePostSeason postSeason2 = syncHistoryRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);

            syncHistoryRemovePost.Movies.Should().BeNull();
            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }
    }
}
