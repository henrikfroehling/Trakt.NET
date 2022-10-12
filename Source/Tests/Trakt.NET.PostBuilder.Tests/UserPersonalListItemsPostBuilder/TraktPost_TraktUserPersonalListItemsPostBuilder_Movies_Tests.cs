namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_ITraktMovie()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_ITraktMovieIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_MovieWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovieWithNotes_MovieIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovieWithNotes(new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovies_ITraktMovie()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsPost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsPost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Notes.Should().BeNull();

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMoviesWithNotes_MovieWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(new List<MovieWithNotes>
                {
                    new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.NOTES),
                    new MovieWithNotes(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsPost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithMoviesWithNotes_MovieIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithMoviesWithNotes(new List<MovieIdsWithNotes>
                {
                    new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new MovieIdsWithNotes(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsPost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsPost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Shows.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }
    }
}
