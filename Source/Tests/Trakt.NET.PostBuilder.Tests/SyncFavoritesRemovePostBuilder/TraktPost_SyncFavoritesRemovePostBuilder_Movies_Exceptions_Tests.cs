﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
