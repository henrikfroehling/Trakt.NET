namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShow_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShow(SHOW_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShow(SHOW_IDS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(SHOW_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(SHOW_IDS_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_CollectedShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(new CollectedShow(SHOW_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_CollectedShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(new CollectedShowIds(SHOW_IDS_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().BeNull();
            postShow.AudioChannels.Should().BeNull();
            postShow.MediaType.Should().BeNull();
            postShow.MediaResolution.Should().BeNull();
            postShow.HDR.Should().BeNull();
            postShow.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(SHOW_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(SHOW_IDS_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ShowWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(new ShowWithMetadata(SHOW_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ShowIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(new ShowIdsWithMetadata(SHOW_IDS_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().BeNull();
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(SHOW_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(SHOW_IDS_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_CollectedShowWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(new CollectedShowWithMetadata(SHOW_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title = SHOW_1.Title;
            postShow.Year = SHOW_1.Year;
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_CollectedShowIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(new CollectedShowIdsWithMetadata(SHOW_IDS_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostShow postShow = syncCollectionPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow.CollectedAt.Should().Be(COLLECTED_AT);
            postShow.Audio.Should().Be(METADATA.Audio);
            postShow.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow.MediaType.Should().Be(METADATA.MediaType);
            postShow.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow.HDR.Should().Be(METADATA.HDR);
            postShow.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShows_ITraktShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShows(SHOWS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title = SHOW_1.Title;
            postShow1.Year = SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title = SHOW_2.Title;
            postShow2.Year = SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_2.Ids.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShows_ITraktShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShows(SHOW_IDS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_IDS_2.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsCollectedAt_CollectedShow()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsCollectedAt(new List<CollectedShow>
                {
                    new CollectedShow(SHOW_1, COLLECTED_AT),
                    new CollectedShow(SHOW_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title = SHOW_1.Title;
            postShow1.Year = SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow1.CollectedAt.Should().Be(COLLECTED_AT);
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title = SHOW_2.Title;
            postShow2.Year = SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_2.Ids.Tmdb);
            postShow2.CollectedAt.Should().Be(COLLECTED_AT);
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsCollectedAt_CollectedShowIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsCollectedAt(new List<CollectedShowIds>
                {
                    new CollectedShowIds(SHOW_IDS_1, COLLECTED_AT),
                    new CollectedShowIds(SHOW_IDS_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow1.CollectedAt.Should().Be(COLLECTED_AT);
            postShow1.Audio.Should().BeNull();
            postShow1.AudioChannels.Should().BeNull();
            postShow1.MediaType.Should().BeNull();
            postShow1.MediaResolution.Should().BeNull();
            postShow1.HDR.Should().BeNull();
            postShow1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_IDS_2.Tmdb);
            postShow2.CollectedAt.Should().Be(COLLECTED_AT);
            postShow2.Audio.Should().BeNull();
            postShow2.AudioChannels.Should().BeNull();
            postShow2.MediaType.Should().BeNull();
            postShow2.MediaResolution.Should().BeNull();
            postShow2.HDR.Should().BeNull();
            postShow2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadata_ShowWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadata(new List<ShowWithMetadata>
                {
                    new ShowWithMetadata(SHOW_1, METADATA),
                    new ShowWithMetadata(SHOW_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title = SHOW_1.Title;
            postShow1.Year = SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().Be(METADATA.Audio);
            postShow1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow1.MediaType.Should().Be(METADATA.MediaType);
            postShow1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow1.HDR.Should().Be(METADATA.HDR);
            postShow1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title = SHOW_2.Title;
            postShow2.Year = SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_2.Ids.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().Be(METADATA.Audio);
            postShow2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow2.MediaType.Should().Be(METADATA.MediaType);
            postShow2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow2.HDR.Should().Be(METADATA.HDR);
            postShow2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadata_ShowIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadata(new List<ShowIdsWithMetadata>
                {
                    new ShowIdsWithMetadata(SHOW_IDS_1, METADATA),
                    new ShowIdsWithMetadata(SHOW_IDS_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow1.CollectedAt.Should().BeNull();
            postShow1.Audio.Should().Be(METADATA.Audio);
            postShow1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow1.MediaType.Should().Be(METADATA.MediaType);
            postShow1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow1.HDR.Should().Be(METADATA.HDR);
            postShow1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_IDS_2.Tmdb);
            postShow2.CollectedAt.Should().BeNull();
            postShow2.Audio.Should().Be(METADATA.Audio);
            postShow2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow2.MediaType.Should().Be(METADATA.MediaType);
            postShow2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow2.HDR.Should().Be(METADATA.HDR);
            postShow2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadataAndCollectedAt_CollectedShowWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadataCollectedAt(new List<CollectedShowWithMetadata>
                {
                    new CollectedShowWithMetadata(SHOW_1, METADATA, COLLECTED_AT),
                    new CollectedShowWithMetadata(SHOW_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title = SHOW_1.Title;
            postShow1.Year = SHOW_1.Year;
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_1.Ids.Tmdb);
            postShow1.CollectedAt.Should().Be(COLLECTED_AT);
            postShow1.Audio.Should().Be(METADATA.Audio);
            postShow1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow1.MediaType.Should().Be(METADATA.MediaType);
            postShow1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow1.HDR.Should().Be(METADATA.HDR);
            postShow1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title = SHOW_2.Title;
            postShow2.Year = SHOW_2.Year;
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_2.Ids.Tmdb);
            postShow2.CollectedAt.Should().Be(COLLECTED_AT);
            postShow2.Audio.Should().Be(METADATA.Audio);
            postShow2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow2.MediaType.Should().Be(METADATA.MediaType);
            postShow2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow2.HDR.Should().Be(METADATA.HDR);
            postShow2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadataAndCollectedAt_CollectedShowIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadataCollectedAt(new List<CollectedShowIdsWithMetadata>
                {
                    new CollectedShowIdsWithMetadata(SHOW_IDS_1, METADATA, COLLECTED_AT),
                    new CollectedShowIdsWithMetadata(SHOW_IDS_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostShow postShow1 = syncCollectionPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(SHOW_IDS_1.Tmdb);
            postShow1.CollectedAt.Should().Be(COLLECTED_AT);
            postShow1.Audio.Should().Be(METADATA.Audio);
            postShow1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow1.MediaType.Should().Be(METADATA.MediaType);
            postShow1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow1.HDR.Should().Be(METADATA.HDR);
            postShow1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostShow postShow2 = syncCollectionPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(SHOW_IDS_2.Tmdb);
            postShow2.CollectedAt.Should().Be(COLLECTED_AT);
            postShow2.Audio.Should().Be(METADATA.Audio);
            postShow2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postShow2.MediaType.Should().Be(METADATA.MediaType);
            postShow2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postShow2.HDR.Should().Be(METADATA.HDR);
            postShow2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }
    }
}
