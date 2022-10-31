namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_1)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithSeason(TraktPost_Tests_Common_Data.SEASON_IDS_1)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionRemovePost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASONS)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_1.Ids.Tmdb);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_2.Ids.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncCollectionRemovePost syncCollectionRemovePost = TraktPost.NewSyncCollectionRemovePost()
                .WithSeasons(TraktPost_Tests_Common_Data.SEASON_IDS)
                .Build();

            syncCollectionRemovePost.Should().NotBeNull();
            syncCollectionRemovePost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionRemovePost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_1.Tmdb);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionRemovePost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SEASON_IDS_2.Tmdb);

            syncCollectionRemovePost.Movies.Should().BeNull();
            syncCollectionRemovePost.Shows.Should().BeNull();
            syncCollectionRemovePost.Episodes.Should().BeNull();
        }
    }
}
