namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovie_ITraktMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title ;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovie_ITraktMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_IDS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_ITraktMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_ITraktMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_CollectedMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(new CollectedMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieCollectedAt_CollectedMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieCollectedAt(new CollectedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().BeNull();
            postMovie.AudioChannels.Should().BeNull();
            postMovie.MediaType.Should().BeNull();
            postMovie.MediaResolution.Should().BeNull();
            postMovie.HDR.Should().BeNull();
            postMovie.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_ITraktMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_ITraktMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_MovieWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(new MovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadata_MovieIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadata(new MovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().BeNull();
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_ITraktMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_ITraktMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_CollectedMovieWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(new CollectedMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovieWithMetadataAndCollectedAt_CollectedMovieIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovieWithMetadataCollectedAt(new CollectedMovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostMovie postMovie = syncCollectionPost.Movies.ToArray()[0];
            postMovie.Title.Should().BeNull();
            postMovie.Year.Should().BeNull();
            postMovie.Ids.Should().NotBeNull();
            postMovie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovies_ITraktMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIES)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.CollectedAt.Should().BeNull();
            postMovie1.Audio.Should().BeNull();
            postMovie1.AudioChannels.Should().BeNull();
            postMovie1.MediaType.Should().BeNull();
            postMovie1.MediaResolution.Should().BeNull();
            postMovie1.HDR.Should().BeNull();
            postMovie1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.CollectedAt.Should().BeNull();
            postMovie2.Audio.Should().BeNull();
            postMovie2.AudioChannels.Should().BeNull();
            postMovie2.MediaType.Should().BeNull();
            postMovie2.MediaResolution.Should().BeNull();
            postMovie2.HDR.Should().BeNull();
            postMovie2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMovies_ITraktMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMovies(TraktPost_Tests_Common_Data.MOVIE_IDS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.CollectedAt.Should().BeNull();
            postMovie1.Audio.Should().BeNull();
            postMovie1.AudioChannels.Should().BeNull();
            postMovie1.MediaType.Should().BeNull();
            postMovie1.MediaResolution.Should().BeNull();
            postMovie1.HDR.Should().BeNull();
            postMovie1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.CollectedAt.Should().BeNull();
            postMovie2.Audio.Should().BeNull();
            postMovie2.AudioChannels.Should().BeNull();
            postMovie2.MediaType.Should().BeNull();
            postMovie2.MediaResolution.Should().BeNull();
            postMovie2.HDR.Should().BeNull();
            postMovie2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesCollectedAt_CollectedMovie()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesCollectedAt(new List<CollectedMovie>
                {
                    new CollectedMovie(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.COLLECTED_AT),
                    new CollectedMovie(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie1.Audio.Should().BeNull();
            postMovie1.AudioChannels.Should().BeNull();
            postMovie1.MediaType.Should().BeNull();
            postMovie1.MediaResolution.Should().BeNull();
            postMovie1.HDR.Should().BeNull();
            postMovie1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie2.Audio.Should().BeNull();
            postMovie2.AudioChannels.Should().BeNull();
            postMovie2.MediaType.Should().BeNull();
            postMovie2.MediaResolution.Should().BeNull();
            postMovie2.HDR.Should().BeNull();
            postMovie2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesCollectedAt_CollectedMovieIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesCollectedAt(new List<CollectedMovieIds>
                {
                    new CollectedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.COLLECTED_AT),
                    new CollectedMovieIds(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie1.Audio.Should().BeNull();
            postMovie1.AudioChannels.Should().BeNull();
            postMovie1.MediaType.Should().BeNull();
            postMovie1.MediaResolution.Should().BeNull();
            postMovie1.HDR.Should().BeNull();
            postMovie1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie2.Audio.Should().BeNull();
            postMovie2.AudioChannels.Should().BeNull();
            postMovie2.MediaType.Should().BeNull();
            postMovie2.MediaResolution.Should().BeNull();
            postMovie2.HDR.Should().BeNull();
            postMovie2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadata_MovieWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadata(new List<MovieWithMetadata>
                {
                    new MovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA),
                    new MovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.CollectedAt.Should().BeNull();
            postMovie1.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie1.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie1.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie1.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie1.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie1.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.CollectedAt.Should().BeNull();
            postMovie2.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie2.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie2.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie2.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie2.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie2.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadata_MovieIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadata(new List<MovieIdsWithMetadata>
                {
                    new MovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA),
                    new MovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.CollectedAt.Should().BeNull();
            postMovie1.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie1.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie1.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie1.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie1.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie1.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.CollectedAt.Should().BeNull();
            postMovie2.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie2.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie2.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie2.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie2.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie2.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadataAndCollectedAt_CollectedMovieWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadataCollectedAt(new List<CollectedMovieWithMetadata>
                {
                    new CollectedMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT),
                    new CollectedMovieWithMetadata(TraktPost_Tests_Common_Data.MOVIE_2, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title = TraktPost_Tests_Common_Data.MOVIE_1.Title;
            postMovie1.Year = TraktPost_Tests_Common_Data.MOVIE_1.Year;
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            postMovie1.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie1.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie1.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie1.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie1.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie1.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie1.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title = TraktPost_Tests_Common_Data.MOVIE_2.Title;
            postMovie2.Year = TraktPost_Tests_Common_Data.MOVIE_2.Year;
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_2.Ids.Tmdb);
            postMovie2.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie2.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie2.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie2.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie2.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie2.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie2.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithMoviesWithMetadataAndCollectedAt_CollectedMovieIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithMoviesWithMetadataCollectedAt(new List<CollectedMovieIdsWithMetadata>
                {
                    new CollectedMovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_1, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT),
                    new CollectedMovieIdsWithMetadata(TraktPost_Tests_Common_Data.MOVIE_IDS_2, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostMovie postMovie1 = syncCollectionPost.Movies.ToArray()[0];
            postMovie1.Title.Should().BeNull();
            postMovie1.Year.Should().BeNull();
            postMovie1.Ids.Should().NotBeNull();
            postMovie1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Trakt);
            postMovie1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Slug);
            postMovie1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Imdb);
            postMovie1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_1.Tmdb);
            postMovie1.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie1.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie1.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie1.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie1.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie1.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie1.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            ITraktSyncCollectionPostMovie postMovie2 = syncCollectionPost.Movies.ToArray()[1];
            postMovie2.Title.Should().BeNull();
            postMovie2.Year.Should().BeNull();
            postMovie2.Ids.Should().NotBeNull();
            postMovie2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Trakt);
            postMovie2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Slug);
            postMovie2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Imdb);
            postMovie2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_IDS_2.Tmdb);
            postMovie2.CollectedAt.Should().Be(TraktPost_Tests_Common_Data.COLLECTED_AT);
            postMovie2.Audio.Should().Be(TraktPost_Tests_Common_Data.METADATA.Audio);
            postMovie2.AudioChannels.Should().Be(TraktPost_Tests_Common_Data.METADATA.AudioChannels);
            postMovie2.MediaType.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaType);
            postMovie2.MediaResolution.Should().Be(TraktPost_Tests_Common_Data.METADATA.MediaResolution);
            postMovie2.HDR.Should().Be(TraktPost_Tests_Common_Data.METADATA.HDR);
            postMovie2.ThreeDimensional.Should().Be(TraktPost_Tests_Common_Data.METADATA.ThreeDimensional);

            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }
    }
}
