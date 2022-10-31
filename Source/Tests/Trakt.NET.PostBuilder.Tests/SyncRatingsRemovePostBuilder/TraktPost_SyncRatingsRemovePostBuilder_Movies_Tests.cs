namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRatingsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsRemovePost.Movies.ToArray()[0];
            postMovie.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Seasons.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncRatingsPostMovie postMovie = syncRatingsRemovePost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Seasons.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithMovies_ITraktMovie()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsRemovePost.Movies.ToArray()[0];
            postMovie1.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Title);
            postMovie1.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Year);
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsRemovePost.Movies.ToArray()[1];
            postMovie2.Title.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Title);
            postMovie2.Year.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Year);
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);

            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Seasons.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktSyncRatingsRemovePost syncRatingsRemovePost = TraktPost.NewSyncRatingsRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            syncRatingsRemovePost.Should().NotBeNull();
            syncRatingsRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRatingsPostMovie postMovie1 = syncRatingsRemovePost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            ITraktSyncRatingsPostMovie postMovie2 = syncRatingsRemovePost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);

            syncRatingsRemovePost.Shows.Should().BeNull();
            syncRatingsRemovePost.Seasons.Should().BeNull();
            syncRatingsRemovePost.Episodes.Should().BeNull();
        }
    }
}
