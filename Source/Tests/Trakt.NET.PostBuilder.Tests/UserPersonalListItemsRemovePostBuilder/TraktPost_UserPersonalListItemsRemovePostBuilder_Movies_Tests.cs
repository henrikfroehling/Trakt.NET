namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithMovie_ITraktMovie()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsRemovePost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostMovie postMovie = userPersonalListItemsRemovePost.Movies.ToArray()[0];
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithMovies_ITraktMovie()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsRemovePost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsRemovePost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostMovie postMovie1 = userPersonalListItemsRemovePost.Movies.ToArray()[0];
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostMovie postMovie2 = userPersonalListItemsRemovePost.Movies.ToArray()[1];
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Shows.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }
    }
}
