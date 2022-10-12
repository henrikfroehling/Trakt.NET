namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovieWithNotes_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movie, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovieWithNotes_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovieWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            MovieWithNotes movieWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovieWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            MovieIdsWithNotes movieIdsWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMoviesWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            List<MovieWithNotes> moviesWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, null)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_WithMoviesWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            List<MovieIdsWithNotes> movieIdsWithNotes = null;

            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, null)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncRecommendationsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
