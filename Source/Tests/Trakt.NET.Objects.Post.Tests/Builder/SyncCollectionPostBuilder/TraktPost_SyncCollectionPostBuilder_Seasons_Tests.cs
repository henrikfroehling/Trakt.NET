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
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeason_ITraktSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeason(SEASON_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeason_ITraktSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeason(SEASON_IDS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_ITraktSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(SEASON_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_ITraktSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(SEASON_IDS_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_CollectedSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(new CollectedSeason(SEASON_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_CollectedSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(new CollectedSeasonIds(SEASON_IDS_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().BeNull();
            postSeason.AudioChannels.Should().BeNull();
            postSeason.MediaType.Should().BeNull();
            postSeason.MediaResolution.Should().BeNull();
            postSeason.HDR.Should().BeNull();
            postSeason.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_ITraktSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(SEASON_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_ITraktSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(SEASON_IDS_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_SeasonWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(new SeasonWithMetadata(SEASON_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_SeasonIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(new SeasonIdsWithMetadata(SEASON_IDS_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().BeNull();
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_ITraktSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(SEASON_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_ITraktSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(SEASON_IDS_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_CollectedSeasonWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(new CollectedSeasonWithMetadata(SEASON_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_CollectedSeasonIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(new CollectedSeasonIdsWithMetadata(SEASON_IDS_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostSeason postSeason = syncCollectionPost.Seasons.ToArray()[0];
            postSeason.Ids.Should().NotBeNull();
            postSeason.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason.Audio.Should().Be(METADATA.Audio);
            postSeason.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason.MediaType.Should().Be(METADATA.MediaType);
            postSeason.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason.HDR.Should().Be(METADATA.HDR);
            postSeason.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasons_ITraktSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasons(SEASONS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason1.CollectedAt.Should().BeNull();
            postSeason1.Audio.Should().BeNull();
            postSeason1.AudioChannels.Should().BeNull();
            postSeason1.MediaType.Should().BeNull();
            postSeason1.MediaResolution.Should().BeNull();
            postSeason1.HDR.Should().BeNull();
            postSeason1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_2.Ids.Tmdb);
            postSeason2.CollectedAt.Should().BeNull();
            postSeason2.Audio.Should().BeNull();
            postSeason2.AudioChannels.Should().BeNull();
            postSeason2.MediaType.Should().BeNull();
            postSeason2.MediaResolution.Should().BeNull();
            postSeason2.HDR.Should().BeNull();
            postSeason2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasons_ITraktSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasons(SEASON_IDS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason1.CollectedAt.Should().BeNull();
            postSeason1.Audio.Should().BeNull();
            postSeason1.AudioChannels.Should().BeNull();
            postSeason1.MediaType.Should().BeNull();
            postSeason1.MediaResolution.Should().BeNull();
            postSeason1.HDR.Should().BeNull();
            postSeason1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_IDS_2.Tmdb);
            postSeason2.CollectedAt.Should().BeNull();
            postSeason2.Audio.Should().BeNull();
            postSeason2.AudioChannels.Should().BeNull();
            postSeason2.MediaType.Should().BeNull();
            postSeason2.MediaResolution.Should().BeNull();
            postSeason2.HDR.Should().BeNull();
            postSeason2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsCollectedAt_CollectedSeason()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsCollectedAt(new List<CollectedSeason>
                {
                    new CollectedSeason(SEASON_1, COLLECTED_AT),
                    new CollectedSeason(SEASON_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason1.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason1.Audio.Should().BeNull();
            postSeason1.AudioChannels.Should().BeNull();
            postSeason1.MediaType.Should().BeNull();
            postSeason1.MediaResolution.Should().BeNull();
            postSeason1.HDR.Should().BeNull();
            postSeason1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_2.Ids.Tmdb);
            postSeason2.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason2.Audio.Should().BeNull();
            postSeason2.AudioChannels.Should().BeNull();
            postSeason2.MediaType.Should().BeNull();
            postSeason2.MediaResolution.Should().BeNull();
            postSeason2.HDR.Should().BeNull();
            postSeason2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsCollectedAt_CollectedSeasonIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsCollectedAt(new List<CollectedSeasonIds>
                {
                    new CollectedSeasonIds(SEASON_IDS_1, COLLECTED_AT),
                    new CollectedSeasonIds(SEASON_IDS_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason1.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason1.Audio.Should().BeNull();
            postSeason1.AudioChannels.Should().BeNull();
            postSeason1.MediaType.Should().BeNull();
            postSeason1.MediaResolution.Should().BeNull();
            postSeason1.HDR.Should().BeNull();
            postSeason1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_IDS_2.Tmdb);
            postSeason2.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason2.Audio.Should().BeNull();
            postSeason2.AudioChannels.Should().BeNull();
            postSeason2.MediaType.Should().BeNull();
            postSeason2.MediaResolution.Should().BeNull();
            postSeason2.HDR.Should().BeNull();
            postSeason2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadata_SeasonWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadata(new List<SeasonWithMetadata>
                {
                    new SeasonWithMetadata(SEASON_1, METADATA),
                    new SeasonWithMetadata(SEASON_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason1.CollectedAt.Should().BeNull();
            postSeason1.Audio.Should().Be(METADATA.Audio);
            postSeason1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason1.MediaType.Should().Be(METADATA.MediaType);
            postSeason1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason1.HDR.Should().Be(METADATA.HDR);
            postSeason1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_2.Ids.Tmdb);
            postSeason2.CollectedAt.Should().BeNull();
            postSeason2.Audio.Should().Be(METADATA.Audio);
            postSeason2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason2.MediaType.Should().Be(METADATA.MediaType);
            postSeason2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason2.HDR.Should().Be(METADATA.HDR);
            postSeason2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadata_SeasonIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadata(new List<SeasonIdsWithMetadata>
                {
                    new SeasonIdsWithMetadata(SEASON_IDS_1, METADATA),
                    new SeasonIdsWithMetadata(SEASON_IDS_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason1.CollectedAt.Should().BeNull();
            postSeason1.Audio.Should().Be(METADATA.Audio);
            postSeason1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason1.MediaType.Should().Be(METADATA.MediaType);
            postSeason1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason1.HDR.Should().Be(METADATA.HDR);
            postSeason1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_IDS_2.Tmdb);
            postSeason2.CollectedAt.Should().BeNull();
            postSeason2.Audio.Should().Be(METADATA.Audio);
            postSeason2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason2.MediaType.Should().Be(METADATA.MediaType);
            postSeason2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason2.HDR.Should().Be(METADATA.HDR);
            postSeason2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadataAndCollectedAt_CollectedSeasonWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadataCollectedAt(new List<CollectedSeasonWithMetadata>
                {
                    new CollectedSeasonWithMetadata(SEASON_1, METADATA, COLLECTED_AT),
                    new CollectedSeasonWithMetadata(SEASON_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_1.Ids.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_1.Ids.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_1.Ids.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_1.Ids.Tmdb);
            postSeason1.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason1.Audio.Should().Be(METADATA.Audio);
            postSeason1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason1.MediaType.Should().Be(METADATA.MediaType);
            postSeason1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason1.HDR.Should().Be(METADATA.HDR);
            postSeason1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_2.Ids.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_2.Ids.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_2.Ids.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_2.Ids.Tmdb);
            postSeason2.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason2.Audio.Should().Be(METADATA.Audio);
            postSeason2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason2.MediaType.Should().Be(METADATA.MediaType);
            postSeason2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason2.HDR.Should().Be(METADATA.HDR);
            postSeason2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadataAndCollectedAt_CollectedSeasonIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadataCollectedAt(new List<CollectedSeasonIdsWithMetadata>
                {
                    new CollectedSeasonIdsWithMetadata(SEASON_IDS_1, METADATA, COLLECTED_AT),
                    new CollectedSeasonIdsWithMetadata(SEASON_IDS_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostSeason postSeason1 = syncCollectionPost.Seasons.ToArray()[0];
            postSeason1.Ids.Should().NotBeNull();
            postSeason1.Ids.Trakt.Should().Be(SEASON_IDS_1.Trakt);
            postSeason1.Ids.Tvdb.Should().Be(SEASON_IDS_1.Tvdb);
            postSeason1.Ids.TvRage.Should().Be(SEASON_IDS_1.TvRage);
            postSeason1.Ids.Tmdb.Should().Be(SEASON_IDS_1.Tmdb);
            postSeason1.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason1.Audio.Should().Be(METADATA.Audio);
            postSeason1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason1.MediaType.Should().Be(METADATA.MediaType);
            postSeason1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason1.HDR.Should().Be(METADATA.HDR);
            postSeason1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostSeason postSeason2 = syncCollectionPost.Seasons.ToArray()[1];
            postSeason2.Ids.Should().NotBeNull();
            postSeason2.Ids.Trakt.Should().Be(SEASON_IDS_2.Trakt);
            postSeason2.Ids.Tvdb.Should().Be(SEASON_IDS_2.Tvdb);
            postSeason2.Ids.TvRage.Should().Be(SEASON_IDS_2.TvRage);
            postSeason2.Ids.Tmdb.Should().Be(SEASON_IDS_2.Tmdb);
            postSeason2.CollectedAt.Should().Be(COLLECTED_AT);
            postSeason2.Audio.Should().Be(METADATA.Audio);
            postSeason2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postSeason2.MediaType.Should().Be(METADATA.MediaType);
            postSeason2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postSeason2.HDR.Should().Be(METADATA.HDR);
            postSeason2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Episodes.Should().BeNull();
        }
    }
}
