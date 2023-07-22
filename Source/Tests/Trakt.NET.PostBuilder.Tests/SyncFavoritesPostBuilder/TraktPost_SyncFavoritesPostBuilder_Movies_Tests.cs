namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().BeNull();

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().BeNull();

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovieWithNotes_ITraktMovie()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovieWithNotes_ITraktMovieIds()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovieWithNotes_MovieWithNotes()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovieWithNotes(new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovieWithNotes_MovieIdsWithNotes()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovieWithNotes(new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES))
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncFavoritesPostMovie postMovie = syncFavoritesPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovies_ITraktMovie()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostMovie postMovie1 = syncFavoritesPost.Movies.ToArray()[0];
            postMovie1.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie1.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktSyncFavoritesPostMovie postMovie2 = syncFavoritesPost.Movies.ToArray()[1];
            postMovie2.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Title);
            postMovie2.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Year);
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Notes.Should().BeNull();

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostMovie postMovie1 = syncFavoritesPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktSyncFavoritesPostMovie postMovie2 = syncFavoritesPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Notes.Should().BeNull();

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMoviesWithNotes_MovieWithNotes()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMoviesWithNotes(new List<MovieWithNotes>
                {
                    new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                    new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostMovie postMovie1 = syncFavoritesPost.Movies.ToArray()[0];
            postMovie1.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie1.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncFavoritesPostMovie postMovie2 = syncFavoritesPost.Movies.ToArray()[1];
            postMovie2.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Title);
            postMovie2.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Year);
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_WithMoviesWithNotes_MovieIdsWithNotes()
        {
            ITraktSyncFavoritesPost syncFavoritesPost = TraktPost.NewSyncFavoritesPost()
                .WithMoviesWithNotes(new List<MovieIdsWithNotes>
                {
                    new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            syncFavoritesPost.Should().NotBeNull();
            syncFavoritesPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncFavoritesPostMovie postMovie1 = syncFavoritesPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktSyncFavoritesPostMovie postMovie2 = syncFavoritesPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            syncFavoritesPost.Shows.Should().BeNull();
        }
    }
}
