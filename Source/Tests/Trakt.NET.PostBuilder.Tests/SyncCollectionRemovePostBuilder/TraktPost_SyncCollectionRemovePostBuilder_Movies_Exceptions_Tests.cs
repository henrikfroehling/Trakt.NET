namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
