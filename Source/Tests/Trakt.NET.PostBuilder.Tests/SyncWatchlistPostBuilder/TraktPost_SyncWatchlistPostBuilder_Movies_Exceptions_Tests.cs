namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovieWithNotes_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movie, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovieWithNotes_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovieWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            MovieWithNotes movieWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovieWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            MovieIdsWithNotes movieIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMoviesWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            List<MovieWithNotes> moviesWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithMoviesWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            List<MovieIdsWithNotes> movieIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
