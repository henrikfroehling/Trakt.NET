namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(movie, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(movieIds, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_WatchedMovie_ArgumentExceptions()
        {
            WatchedMovie movie = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovieWatchedAt_WatchedMovieIds_ArgumentExceptions()
        {
            WatchedMovieIds movieIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovieWatchedAt(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMoviesWatchedAt_WatchedMovie_ArgumentExceptions()
        {
            List<WatchedMovie> movies = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMoviesWatchedAt(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithMoviesWatchedAt_WatchedMovieIds_ArgumentExceptions()
        {
            List<WatchedMovieIds> moviesIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithMoviesWatchedAt(moviesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
