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
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisode_ITraktEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisode(EPISODE_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisode_ITraktEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisode(EPISODE_IDS_1)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_ITraktEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(EPISODE_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_ITraktEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(EPISODE_IDS_1, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_CollectedEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(new CollectedEpisode(EPISODE_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_CollectedEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(new CollectedEpisodeIds(EPISODE_IDS_1, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().BeNull();
            postEpisode.AudioChannels.Should().BeNull();
            postEpisode.MediaType.Should().BeNull();
            postEpisode.MediaResolution.Should().BeNull();
            postEpisode.HDR.Should().BeNull();
            postEpisode.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_ITraktEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(EPISODE_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_ITraktEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(EPISODE_IDS_1, METADATA)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_EpisodeWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(new EpisodeWithMetadata(EPISODE_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_EpisodeIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(new EpisodeIdsWithMetadata(EPISODE_IDS_1, METADATA))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().BeNull();
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_ITraktEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(EPISODE_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_ITraktEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(EPISODE_IDS_1, METADATA, COLLECTED_AT)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_CollectedEpisodeWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(new CollectedEpisodeWithMetadata(EPISODE_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_CollectedEpisodeIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(new CollectedEpisodeIdsWithMetadata(EPISODE_IDS_1, METADATA, COLLECTED_AT))
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktSyncCollectionPostEpisode postEpisode = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode.Ids.Should().NotBeNull();
            postEpisode.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode.Audio.Should().Be(METADATA.Audio);
            postEpisode.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode.MediaType.Should().Be(METADATA.MediaType);
            postEpisode.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode.HDR.Should().Be(METADATA.HDR);
            postEpisode.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodes_ITraktEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodes(EPISODES)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode1.CollectedAt.Should().BeNull();
            postEpisode1.Audio.Should().BeNull();
            postEpisode1.AudioChannels.Should().BeNull();
            postEpisode1.MediaType.Should().BeNull();
            postEpisode1.MediaResolution.Should().BeNull();
            postEpisode1.HDR.Should().BeNull();
            postEpisode1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_2.Ids.Tmdb);
            postEpisode2.CollectedAt.Should().BeNull();
            postEpisode2.Audio.Should().BeNull();
            postEpisode2.AudioChannels.Should().BeNull();
            postEpisode2.MediaType.Should().BeNull();
            postEpisode2.MediaResolution.Should().BeNull();
            postEpisode2.HDR.Should().BeNull();
            postEpisode2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodes_ITraktEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodes(EPISODE_IDS)
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode1.CollectedAt.Should().BeNull();
            postEpisode1.Audio.Should().BeNull();
            postEpisode1.AudioChannels.Should().BeNull();
            postEpisode1.MediaType.Should().BeNull();
            postEpisode1.MediaResolution.Should().BeNull();
            postEpisode1.HDR.Should().BeNull();
            postEpisode1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_IDS_2.Tmdb);
            postEpisode2.CollectedAt.Should().BeNull();
            postEpisode2.Audio.Should().BeNull();
            postEpisode2.AudioChannels.Should().BeNull();
            postEpisode2.MediaType.Should().BeNull();
            postEpisode2.MediaResolution.Should().BeNull();
            postEpisode2.HDR.Should().BeNull();
            postEpisode2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesCollectedAt_CollectedEpisode()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesCollectedAt(new List<CollectedEpisode>
                {
                    new CollectedEpisode(EPISODE_1, COLLECTED_AT),
                    new CollectedEpisode(EPISODE_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode1.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode1.Audio.Should().BeNull();
            postEpisode1.AudioChannels.Should().BeNull();
            postEpisode1.MediaType.Should().BeNull();
            postEpisode1.MediaResolution.Should().BeNull();
            postEpisode1.HDR.Should().BeNull();
            postEpisode1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_2.Ids.Tmdb);
            postEpisode2.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode2.Audio.Should().BeNull();
            postEpisode2.AudioChannels.Should().BeNull();
            postEpisode2.MediaType.Should().BeNull();
            postEpisode2.MediaResolution.Should().BeNull();
            postEpisode2.HDR.Should().BeNull();
            postEpisode2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesCollectedAt_CollectedEpisodeIds()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesCollectedAt(new List<CollectedEpisodeIds>
                {
                    new CollectedEpisodeIds(EPISODE_IDS_1, COLLECTED_AT),
                    new CollectedEpisodeIds(EPISODE_IDS_2, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode1.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode1.Audio.Should().BeNull();
            postEpisode1.AudioChannels.Should().BeNull();
            postEpisode1.MediaType.Should().BeNull();
            postEpisode1.MediaResolution.Should().BeNull();
            postEpisode1.HDR.Should().BeNull();
            postEpisode1.ThreeDimensional.Should().BeNull();

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_IDS_2.Tmdb);
            postEpisode2.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode2.Audio.Should().BeNull();
            postEpisode2.AudioChannels.Should().BeNull();
            postEpisode2.MediaType.Should().BeNull();
            postEpisode2.MediaResolution.Should().BeNull();
            postEpisode2.HDR.Should().BeNull();
            postEpisode2.ThreeDimensional.Should().BeNull();

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadata_EpisodeWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadata(new List<EpisodeWithMetadata>
                {
                    new EpisodeWithMetadata(EPISODE_1, METADATA),
                    new EpisodeWithMetadata(EPISODE_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode1.CollectedAt.Should().BeNull();
            postEpisode1.Audio.Should().Be(METADATA.Audio);
            postEpisode1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode1.MediaType.Should().Be(METADATA.MediaType);
            postEpisode1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode1.HDR.Should().Be(METADATA.HDR);
            postEpisode1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_2.Ids.Tmdb);
            postEpisode2.CollectedAt.Should().BeNull();
            postEpisode2.Audio.Should().Be(METADATA.Audio);
            postEpisode2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode2.MediaType.Should().Be(METADATA.MediaType);
            postEpisode2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode2.HDR.Should().Be(METADATA.HDR);
            postEpisode2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadata_EpisodeIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadata(new List<EpisodeIdsWithMetadata>
                {
                    new EpisodeIdsWithMetadata(EPISODE_IDS_1, METADATA),
                    new EpisodeIdsWithMetadata(EPISODE_IDS_2, METADATA)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode1.CollectedAt.Should().BeNull();
            postEpisode1.Audio.Should().Be(METADATA.Audio);
            postEpisode1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode1.MediaType.Should().Be(METADATA.MediaType);
            postEpisode1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode1.HDR.Should().Be(METADATA.HDR);
            postEpisode1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_IDS_2.Tmdb);
            postEpisode2.CollectedAt.Should().BeNull();
            postEpisode2.Audio.Should().Be(METADATA.Audio);
            postEpisode2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode2.MediaType.Should().Be(METADATA.MediaType);
            postEpisode2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode2.HDR.Should().Be(METADATA.HDR);
            postEpisode2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadataAndCollectedAt_CollectedEpisodeWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadataCollectedAt(new List<CollectedEpisodeWithMetadata>
                {
                    new CollectedEpisodeWithMetadata(EPISODE_1, METADATA, COLLECTED_AT),
                    new CollectedEpisodeWithMetadata(EPISODE_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_1.Ids.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_1.Ids.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_1.Ids.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_1.Ids.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_1.Ids.Tmdb);
            postEpisode1.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode1.Audio.Should().Be(METADATA.Audio);
            postEpisode1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode1.MediaType.Should().Be(METADATA.MediaType);
            postEpisode1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode1.HDR.Should().Be(METADATA.HDR);
            postEpisode1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_2.Ids.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_2.Ids.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_2.Ids.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_2.Ids.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_2.Ids.Tmdb);
            postEpisode2.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode2.Audio.Should().Be(METADATA.Audio);
            postEpisode2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode2.MediaType.Should().Be(METADATA.MediaType);
            postEpisode2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode2.HDR.Should().Be(METADATA.HDR);
            postEpisode2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadataAndCollectedAt_CollectedEpisodeIdsWithMetadata()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadataCollectedAt(new List<CollectedEpisodeIdsWithMetadata>
                {
                    new CollectedEpisodeIdsWithMetadata(EPISODE_IDS_1, METADATA, COLLECTED_AT),
                    new CollectedEpisodeIdsWithMetadata(EPISODE_IDS_2, METADATA, COLLECTED_AT)
                })
                .Build();

            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Episodes.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncCollectionPostEpisode postEpisode1 = syncCollectionPost.Episodes.ToArray()[0];
            postEpisode1.Ids.Should().NotBeNull();
            postEpisode1.Ids.Trakt.Should().Be(EPISODE_IDS_1.Trakt);
            postEpisode1.Ids.Imdb.Should().Be(EPISODE_IDS_1.Imdb);
            postEpisode1.Ids.Tvdb.Should().Be(EPISODE_IDS_1.Tvdb);
            postEpisode1.Ids.TvRage.Should().Be(EPISODE_IDS_1.TvRage);
            postEpisode1.Ids.Tmdb.Should().Be(EPISODE_IDS_1.Tmdb);
            postEpisode1.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode1.Audio.Should().Be(METADATA.Audio);
            postEpisode1.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode1.MediaType.Should().Be(METADATA.MediaType);
            postEpisode1.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode1.HDR.Should().Be(METADATA.HDR);
            postEpisode1.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            ITraktSyncCollectionPostEpisode postEpisode2 = syncCollectionPost.Episodes.ToArray()[1];
            postEpisode2.Ids.Should().NotBeNull();
            postEpisode2.Ids.Trakt.Should().Be(EPISODE_IDS_2.Trakt);
            postEpisode2.Ids.Imdb.Should().Be(EPISODE_IDS_2.Imdb);
            postEpisode2.Ids.Tvdb.Should().Be(EPISODE_IDS_2.Tvdb);
            postEpisode2.Ids.TvRage.Should().Be(EPISODE_IDS_2.TvRage);
            postEpisode2.Ids.Tmdb.Should().Be(EPISODE_IDS_2.Tmdb);
            postEpisode2.CollectedAt.Should().Be(COLLECTED_AT);
            postEpisode2.Audio.Should().Be(METADATA.Audio);
            postEpisode2.AudioChannels.Should().Be(METADATA.AudioChannels);
            postEpisode2.MediaType.Should().Be(METADATA.MediaType);
            postEpisode2.MediaResolution.Should().Be(METADATA.MediaResolution);
            postEpisode2.HDR.Should().Be(METADATA.HDR);
            postEpisode2.ThreeDimensional.Should().Be(METADATA.ThreeDimensional);

            syncCollectionPost.Movies.Should().BeNull();
            syncCollectionPost.Shows.Should().BeNull();
            syncCollectionPost.Seasons.Should().BeNull();
        }
    }
}
