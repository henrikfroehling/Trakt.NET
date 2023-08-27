namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Scrobbles;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_MovieScrobblePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Empty_Build()
        {
            Func<ITraktMovieScrobblePost> act = () => TraktPost.NewMovieScrobblePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Scrobble_Movie()
        {
            ITraktMovieScrobblePost movieScrobblePost = TraktPost.NewMovieScrobblePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .Build();

            movieScrobblePost.Should().NotBeNull();
            movieScrobblePost.Movie.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieScrobblePost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieScrobblePost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieScrobblePost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            movieScrobblePost.AppVersion.Should().BeNull();
            movieScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Scrobble_MovieIds()
        {
            ITraktMovieScrobblePost movieScrobblePost = TraktPost.NewMovieScrobblePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .Build();

            movieScrobblePost.Should().NotBeNull();
            movieScrobblePost.Movie.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            movieScrobblePost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            movieScrobblePost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            movieScrobblePost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            movieScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            movieScrobblePost.AppVersion.Should().BeNull();
            movieScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Scrobble_Movie_AppVersion()
        {
            ITraktMovieScrobblePost movieScrobblePost = TraktPost.NewMovieScrobblePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .Build();

            movieScrobblePost.Should().NotBeNull();
            movieScrobblePost.Movie.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieScrobblePost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieScrobblePost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieScrobblePost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            movieScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            movieScrobblePost.AppDate.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Scrobble_Movie_AppDate()
        {
            ITraktMovieScrobblePost movieScrobblePost = TraktPost.NewMovieScrobblePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            movieScrobblePost.Should().NotBeNull();
            movieScrobblePost.Movie.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieScrobblePost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieScrobblePost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieScrobblePost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            movieScrobblePost.AppVersion.Should().BeNull();
            movieScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }

        [Fact]
        public void Test_TraktPost_MovieScrobblePostBuilder_Complete()
        {
            ITraktMovieScrobblePost movieScrobblePost = TraktPost.NewMovieScrobblePost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithProgress(TraktPost_Tests_Common_Data.PROGRESS)
                .WithAppVersion(TraktPost_Tests_Common_Data.APP_VERSION)
                .WithAppDate(TraktPost_Tests_Common_Data.APP_DATE)
                .Build();

            movieScrobblePost.Should().NotBeNull();
            movieScrobblePost.Movie.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Should().NotBeNull();
            movieScrobblePost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieScrobblePost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieScrobblePost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieScrobblePost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieScrobblePost.Progress.Should().Be(TraktPost_Tests_Common_Data.PROGRESS);
            movieScrobblePost.AppVersion.Should().Be(TraktPost_Tests_Common_Data.APP_VERSION);
            movieScrobblePost.AppDate.Should().Be(TraktPost_Tests_Common_Data.APP_DATE);
        }
    }
}
