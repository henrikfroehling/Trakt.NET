namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistRemovePost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODES)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistRemovePost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistRemovePost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktSyncWatchlistRemovePost syncWatchlistRemovePost = TraktPost.NewSyncWatchlistRemovePost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODE_IDS)
                .Build();

            syncWatchlistRemovePost.Should().NotBeNull();
            syncWatchlistRemovePost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistRemovePost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistRemovePost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);

            syncWatchlistRemovePost.Movies.Should().BeNull();
            syncWatchlistRemovePost.Shows.Should().BeNull();
            syncWatchlistRemovePost.Seasons.Should().BeNull();
        }
    }
}
