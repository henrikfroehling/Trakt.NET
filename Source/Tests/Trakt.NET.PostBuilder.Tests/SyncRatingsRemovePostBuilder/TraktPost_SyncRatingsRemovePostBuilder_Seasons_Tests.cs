namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            syncRatingsRemovePost.Movies.Should().BeNull();
            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostSeason postSeason = syncRatingsRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            syncRatingsRemovePost.Movies.Should().BeNull();
            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);

            syncRatingsRemovePost.Movies.Should().BeNull();
            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostSeason postSeason1 = syncRatingsRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            ITraktSyncRatingsPostSeason postSeason2 = syncRatingsRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);

            syncRatingsRemovePost.Movies.Should().BeNull();
            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }
    }
}
