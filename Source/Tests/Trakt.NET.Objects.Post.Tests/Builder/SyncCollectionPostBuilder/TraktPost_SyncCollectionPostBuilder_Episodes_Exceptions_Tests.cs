namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisode_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisode(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisode_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisode(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(episode, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(episodeIds, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_CollectedEpisode_ArgumentExceptions()
        {
            CollectedEpisode episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeCollectedAt_CollectedEpisodeIds_ArgumentExceptions()
        {
            CollectedEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeCollectedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(episode, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(TraktPost_Tests_Common_Data.EPISODE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(episodeIds, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(TraktPost_Tests_Common_Data.EPISODE_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_EpisodeWithMetadata_ArgumentExceptions()
        {
            EpisodeWithMetadata episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadata_EpisodeIdsWithMetadata_ArgumentExceptions()
        {
            EpisodeIdsWithMetadata episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadata(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_ITraktEpisode_ArgumentExceptions()
        {
            ITraktEpisode episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(episode, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(TraktPost_Tests_Common_Data.EPISODE_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_ITraktEpisodeIds_ArgumentExceptions()
        {
            ITraktEpisodeIds episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(episodeIds, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(TraktPost_Tests_Common_Data.EPISODE_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_CollectedEpisodeWithMetadata_ArgumentExceptions()
        {
            CollectedEpisodeWithMetadata episode = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(episode)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodeWithMetadataAndCollectedAt_CollectedEpisodeIdsWithMetadata_ArgumentExceptions()
        {
            CollectedEpisodeIdsWithMetadata episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodeWithMetadataCollectedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodes_ITraktEpisode_ArgumentExceptions()
        {
            List<ITraktEpisode> episodes = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodes(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodes_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ITraktEpisodeIds> episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodes(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesCollectedAt_CollectedEpisode_ArgumentExceptions()
        {
            List<CollectedEpisode> episodes = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesCollectedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesCollectedAt_CollectedEpisodeIds_ArgumentExceptions()
        {
            List<CollectedEpisodeIds> episodesIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesCollectedAt(episodesIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadata_EpisodeWithMetadata_ArgumentExceptions()
        {
            List<EpisodeWithMetadata> episodes = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadata(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadata_EpisodeIdsWithMetadata_ArgumentExceptions()
        {
            List<EpisodeIdsWithMetadata> episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadata(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadataAndCollectedAt_CollectedEpisodeWithMetadata_ArgumentExceptions()
        {
            List<CollectedEpisodeWithMetadata> episodes = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadataCollectedAt(episodes)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithEpisodesWithMetadataAndCollectedAt_CollectedEpisodeIdsWithMetadata_ArgumentExceptions()
        {
            List<CollectedEpisodeIdsWithMetadata> episodeIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithEpisodesWithMetadataCollectedAt(episodeIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
