namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisode(TraktPost_Tests_Common_Data.EPISODE_IDS_1)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodeWithNotes_ITraktEpisode()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodeWithNotes_ITraktEpisodeIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodeWithNotes_EpisodeWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodeWithNotes(new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodeWithNotes_EpisodeIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodeWithNotes(new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncWatchlistPostEpisode postEpisode = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODES)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodes(TraktPost_Tests_Common_Data.EPISODE_IDS)
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Notes.Should().BeNull();

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Notes.Should().BeNull();

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodesWithNotes_EpisodeWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodesWithNotes(new List<EpisodeWithNotes>
                {
                    new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_1, TraktPost_Tests_Common_Data.NOTES),
                    new EpisodeWithNotes(TraktPost_Tests_Common_Data.EPISODE_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_1.Ids.Tmdb);
            postEpisode1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_2.Ids.Tmdb);
            postEpisode2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithEpisodesWithNotes_EpisodeIdsWithNotes()
        {
            ITraktSyncWatchlistPost syncWatchlistPost = TraktPost.NewSyncWatchlistPost()
                .WithEpisodesWithNotes(new List<EpisodeIdsWithNotes>
                {
                    new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new EpisodeIdsWithNotes(TraktPost_Tests_Common_Data.EPISODE_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncWatchlistPost.Should().NotBeNull();
            syncWatchlistPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncWatchlistPostEpisode postEpisode1 = syncWatchlistPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_1.Tmdb);
            postEpisode1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncWatchlistPostEpisode postEpisode2 = syncWatchlistPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.EPISODE_IDS_2.Tmdb);
            postEpisode2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncWatchlistPost.Movies.Should().BeNull();
            syncWatchlistPost.Shows.Should().BeNull();
            syncWatchlistPost.Seasons.Should().BeNull();
        }
    }
}
