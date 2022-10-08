namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovie(episode, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovie(episodeIds, TraktPost_Tests_Common_Data.RATING)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_RatingsMovie_ArgumentExceptions()
        {
            RatingsMovie episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovie(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovie_RatingsMovieIds_ArgumentExceptions()
        {
            RatingsMovieIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovie(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(episode, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(episodeIds, TraktPost_Tests_Common_Data.RATING, TraktPost_Tests_Common_Data.RATED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_RatingsMovieRatedAt_ArgumentExceptions()
        {
            RatingsMovieRatedAt episode = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovieRatedAt_RatingsMovieIdsRatedAt_ArgumentExceptions()
        {
            RatingsMovieIdsRatedAt episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovieRatedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovies_RatingsMovie_ArgumentExceptions()
        {
            List<RatingsMovie> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovies(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMovies_RatingsMovieIds_ArgumentExceptions()
        {
            List<RatingsMovieIds> episodeIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMovies(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMoviesRatedAt_RatingsMovieRatedAt_ArgumentExceptions()
        {
            List<RatingsMovieRatedAt> episodes = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMoviesRatedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_WithMoviesRatedAt_RatingsMovieIdsRatedAt_ArgumentExceptions()
        {
            List<RatingsMovieIdsRatedAt> episodesIds = null;

            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost()
                .WithMoviesRatedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
