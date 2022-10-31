namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movie, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            MovieWithNotes movieWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieWithNotes = new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            MovieIdsWithNotes movieIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMoviesWithNotes_MovieWithNotes_ArgumentExceptions()
        {
            List<MovieWithNotes> moviesWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            moviesWithNotes = new List<MovieWithNotes>
            {
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(moviesWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMoviesWithNotes_MovieIdsWithNotes_ArgumentExceptions()
        {
            List<MovieIdsWithNotes> movieIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            movieIdsWithNotes = new List<MovieIdsWithNotes>
            {
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(movieIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
