namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsRemovePostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncRecommendationsRemovePost> act = () => TraktPost.NewSyncRecommendationsRemovePost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsRemovePostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncRecommendationsRemovePost> act = () => TraktPost.NewSyncRecommendationsRemovePost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsRemovePostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncRecommendationsRemovePost> act = () => TraktPost.NewSyncRecommendationsRemovePost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRecommendationsRemovePostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncRecommendationsRemovePost> act = () => TraktPost.NewSyncRecommendationsRemovePost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
