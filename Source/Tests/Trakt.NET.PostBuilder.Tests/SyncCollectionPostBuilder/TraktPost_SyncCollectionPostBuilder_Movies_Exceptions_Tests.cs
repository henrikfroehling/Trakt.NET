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
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovie_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovie(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovie_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovie(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(movie, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(movieIds, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_CollectedMovie_ArgumentExceptions()
        {
            CollectedMovie movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_CollectedMovieIds_ArgumentExceptions()
        {
            CollectedMovieIds movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(movie, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(movieIds, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_MovieWithMetadata_ArgumentExceptions()
        {
            MovieWithMetadata movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_MovieIdsWithMetadata_ArgumentExceptions()
        {
            MovieIdsWithMetadata movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_ITraktMovie_ArgumentExceptions()
        {
            ITraktMovie movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(movie, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(TraktPost_Tests_Common_Data.MOVIE_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_ITraktMovieIds_ArgumentExceptions()
        {
            ITraktMovieIds movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(movieIds, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(TraktPost_Tests_Common_Data.MOVIE_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_CollectedMovieWithMetadata_ArgumentExceptions()
        {
            CollectedMovieWithMetadata movie = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(movie)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_CollectedMovieIdsWithMetadata_ArgumentExceptions()
        {
            CollectedMovieIdsWithMetadata movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovies_ITraktMovie_ArgumentExceptions()
        {
            List<ITraktMovie> movies = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovies(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovies_ITraktMovieIds_ArgumentExceptions()
        {
            List<ITraktMovieIds> movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMovies(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesCollectedAt_CollectedMovie_ArgumentExceptions()
        {
            List<CollectedMovie> movies = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesCollectedAt(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesCollectedAt_CollectedMovieIds_ArgumentExceptions()
        {
            List<CollectedMovieIds> moviesIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesCollectedAt(moviesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadata_MovieWithMetadata_ArgumentExceptions()
        {
            List<MovieWithMetadata> movies = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadata(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadata_MovieIdsWithMetadata_ArgumentExceptions()
        {
            List<MovieIdsWithMetadata> movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadata(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadataAndCollectedAt_CollectedMovieWithMetadata_ArgumentExceptions()
        {
            List<CollectedMovieWithMetadata> movies = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadataCollectedAt(movies)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadataAndCollectedAt_CollectedMovieIdsWithMetadata_ArgumentExceptions()
        {
            List<CollectedMovieIdsWithMetadata> movieIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadataCollectedAt(movieIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
