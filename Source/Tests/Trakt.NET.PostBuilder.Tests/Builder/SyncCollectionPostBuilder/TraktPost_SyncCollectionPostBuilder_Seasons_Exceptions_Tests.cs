namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(season, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(seasonIds, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_CollectedSeason_ArgumentExceptions()
        {
            CollectedSeason season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonCollectedAt_CollectedSeasonIds_ArgumentExceptions()
        {
            CollectedSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonCollectedAt(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(season, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(TraktPost_Tests_Common_Data.SEASON_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(seasonIds, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(TraktPost_Tests_Common_Data.SEASON_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_SeasonWithMetadata_ArgumentExceptions()
        {
            SeasonWithMetadata season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadata_SeasonIdsWithMetadata_ArgumentExceptions()
        {
            SeasonIdsWithMetadata seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadata(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(season, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(TraktPost_Tests_Common_Data.SEASON_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(seasonIds, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(TraktPost_Tests_Common_Data.SEASON_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_CollectedSeasonWithMetadata_ArgumentExceptions()
        {
            CollectedSeasonWithMetadata season = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonWithMetadataAndCollectedAt_CollectedSeasonIdsWithMetadata_ArgumentExceptions()
        {
            CollectedSeasonIdsWithMetadata seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonWithMetadataCollectedAt(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsCollectedAt_CollectedSeason_ArgumentExceptions()
        {
            List<CollectedSeason> seasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsCollectedAt(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsCollectedAt_CollectedSeasonIds_ArgumentExceptions()
        {
            List<CollectedSeasonIds> seasonsIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsCollectedAt(seasonsIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadata_SeasonWithMetadata_ArgumentExceptions()
        {
            List<SeasonWithMetadata> seasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadata(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadata_SeasonIdsWithMetadata_ArgumentExceptions()
        {
            List<SeasonIdsWithMetadata> seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadata(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadataAndCollectedAt_CollectedSeasonWithMetadata_ArgumentExceptions()
        {
            List<CollectedSeasonWithMetadata> seasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadataCollectedAt(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithSeasonsWithMetadataAndCollectedAt_CollectedSeasonIdsWithMetadata_ArgumentExceptions()
        {
            List<CollectedSeasonIdsWithMetadata> seasonIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithSeasonsWithMetadataCollectedAt(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
