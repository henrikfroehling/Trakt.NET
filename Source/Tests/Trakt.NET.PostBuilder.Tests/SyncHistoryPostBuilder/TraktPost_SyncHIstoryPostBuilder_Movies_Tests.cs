namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.WatchedAt.Should().BeNull();

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.WatchedAt.Should().BeNull();

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_ITraktMovie()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_ITraktMovieIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_WatchedMovie()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(new WatchedMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_WatchedMovieIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(new WatchedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT))
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryPostMovie postMovie = syncHistoryPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovies_ITraktMovie()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostMovie postMovie1 = syncHistoryPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostMovie postMovie2 = syncHistoryPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.WatchedAt.Should().BeNull();

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostMovie postMovie1 = syncHistoryPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.WatchedAt.Should().BeNull();

            ITraktSyncHistoryPostMovie postMovie2 = syncHistoryPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.WatchedAt.Should().BeNull();

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMoviesWatchedAt_WatchedMovie()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMoviesWatchedAt(new List<WatchedMovie>
                {
                    new WatchedMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedMovie(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostMovie postMovie1 = syncHistoryPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostMovie postMovie2 = syncHistoryPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMoviesWatchedAt_WatchedMovieIds()
        {
            ITraktSyncHistoryPost syncHistoryPost = TraktPost.NewSyncHistoryPost()
                .WithMoviesWatchedAt(new List<WatchedMovieIds>
                {
                    new WatchedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.WATCHED_AT),
                    new WatchedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.WATCHED_AT)
                })
                .Build();

            syncHistoryPost.Should().NotBeNull();
            syncHistoryPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryPostMovie postMovie1 = syncHistoryPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            ITraktSyncHistoryPostMovie postMovie2 = syncHistoryPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.WatchedAt.Should().Be(TraktPost_Tests_Common_Data.WATCHED_AT);

            syncHistoryPost.Shows.Should().BeNull();
            syncHistoryPost.Seasons.Should().BeNull();
            syncHistoryPost.Episodes.Should().BeNull();
        }
    }
}
