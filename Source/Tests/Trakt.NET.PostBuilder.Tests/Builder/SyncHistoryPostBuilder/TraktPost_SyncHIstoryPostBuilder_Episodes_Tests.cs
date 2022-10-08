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
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_ITraktEpisode()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_ITraktEpisodeIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_WatchedEpisode()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(new WatchedEpisode(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodeWatchedAt_WatchedEpisodeIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodeWatchedAt(new WatchedEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostEpisode postEpisode = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODES)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostEpisode postEpisode1 = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostEpisode postEpisode2 = syncHistoryPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODE_IDS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostEpisode postEpisode1 = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostEpisode postEpisode2 = syncHistoryPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.WatchedAt.Should().BeNull();

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodesWatchedAt_WatchedEpisode()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodesWatchedAt(new List<WatchedEpisode>
                {
                    new WatchedEpisode(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedEpisode(TraktPost_Tests_Common_Data.EPISODE_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostEpisode postEpisode1 = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostEpisode postEpisode2 = syncHistoryPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithEpisodesWatchedAt_WatchedEpisodeIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithEpisodesWatchedAt(new List<WatchedEpisodeIds>
                {
                    new WatchedEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedEpisodeIds(TraktPost_Tests_Common_Data.EPISODE_IDS_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostEpisode postEpisode1 = syncHistoryPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostEpisode postEpisode2 = syncHistoryPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Movies.Should().BeNull();
            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
        }
    }
}
