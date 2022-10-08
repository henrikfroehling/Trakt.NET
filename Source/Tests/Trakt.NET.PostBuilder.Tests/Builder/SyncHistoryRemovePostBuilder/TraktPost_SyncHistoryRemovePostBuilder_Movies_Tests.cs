namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostMovie postMovie = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncHistoryRemovePostMovie postMovie = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovies_ITraktMovie()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostMovie postMovie1 = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);

            ITraktSyncHistoryRemovePostMovie postMovie2 = syncHistoryRemovePost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);

            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktSyncHistoryRemovePost syncHistoryRemovePost = TraktPost.NewSyncHistoryRemovePost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            syncHistoryRemovePost.Should().NotBeNull();
            syncHistoryRemovePost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncHistoryRemovePostMovie postMovie1 = syncHistoryRemovePost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);

            ITraktSyncHistoryRemovePostMovie postMovie2 = syncHistoryRemovePost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);

            syncHistoryRemovePost.Shows.Should().BeNull();
            syncHistoryRemovePost.Seasons.Should().BeNull();
            syncHistoryRemovePost.Episodes.Should().BeNull();
            syncHistoryRemovePost.HistoryIds.Should().BeNull();
        }
    }
}
