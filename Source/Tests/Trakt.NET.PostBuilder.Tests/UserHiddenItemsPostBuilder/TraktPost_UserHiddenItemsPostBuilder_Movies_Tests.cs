namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostMovie postMovie = userHiddenItemsPost.Movies.ToArray()[0];
            postMovie.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostMovie postMovie = userHiddenItemsPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovies_ITraktMovie()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostMovie postMovie1 = userHiddenItemsPost.Movies.ToArray()[0];
            postMovie1.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie1.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            ITraktUserHiddenItemsPostMovie postMovie2 = userHiddenItemsPost.Movies.ToArray()[1];
            postMovie2.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Title);
            postMovie2.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Year);
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);

            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostMovie postMovie1 = userHiddenItemsPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            ITraktUserHiddenItemsPostMovie postMovie2 = userHiddenItemsPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);

            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }
    }
}
