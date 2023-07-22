namespace TraktNet.Objects.Post.Tests.Syncs.Favorites.Implementations
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("Objects.Post.Syncs.Favorites.Implementations")]
    public class TraktSyncFavoritesRemovePost_Tests
    {
        [Fact]
        public void Test_TraktSyncFavoritesRemovePost_Validate()
        {
            ITraktSyncFavoritesRemovePost syncFavoritesRemovePost = new TraktSyncFavoritesRemovePost();

            // movies = null, shows = null
            Action act = () => syncFavoritesRemovePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = null
            syncFavoritesRemovePost.Movies = new List<ITraktSyncFavoritesPostMovie>();
            act.Should().Throw<TraktPostValidationException>();

            // movies = empty, shows = empty
            syncFavoritesRemovePost.Shows = new List<ITraktSyncFavoritesPostShow>();
            act.Should().Throw<TraktPostValidationException>();

            // movies with at least one item, shows = empty
            (syncFavoritesRemovePost.Movies as List<ITraktSyncFavoritesPostMovie>).Add(new TraktSyncFavoritesPostMovie());
            act.Should().NotThrow();

            // movies = empty, shows with at least one item
            (syncFavoritesRemovePost.Movies as List<ITraktSyncFavoritesPostMovie>).Clear();
            (syncFavoritesRemovePost.Shows as List<ITraktSyncFavoritesPostShow>).Add(new TraktSyncFavoritesPostShow());
            act.Should().NotThrow();
        }
    }
}
