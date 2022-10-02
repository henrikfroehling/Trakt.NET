namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(show, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(showIds, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_CollectedShow_ArgumentExceptions()
        {
            CollectedShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowCollectedAt_CollectedShowIds_ArgumentExceptions()
        {
            CollectedShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowCollectedAt(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(show, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(showIds, TraktPost_Tests_Common_Data.METADATA)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ShowWithMetadata_ArgumentExceptions()
        {
            ShowWithMetadata show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadata_ShowIdsWithMetadata_ArgumentExceptions()
        {
            ShowIdsWithMetadata showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadata(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(show, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(TraktPost_Tests_Common_Data.SHOW_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(showIds, TraktPost_Tests_Common_Data.METADATA, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(TraktPost_Tests_Common_Data.SHOW_1, null, TraktPost_Tests_Common_Data.COLLECTED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_CollectedShowWithMetadata_ArgumentExceptions()
        {
            CollectedShowWithMetadata show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowWithMetadataAndCollectedAt_CollectedShowIdsWithMetadata_ArgumentExceptions()
        {
            CollectedShowIdsWithMetadata showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowWithMetadataCollectedAt(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsCollectedAt_CollectedShow_ArgumentExceptions()
        {
            List<CollectedShow> shows = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsCollectedAt(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsCollectedAt_CollectedShowIds_ArgumentExceptions()
        {
            List<CollectedShowIds> showsIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsCollectedAt(showsIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadata_ShowWithMetadata_ArgumentExceptions()
        {
            List<ShowWithMetadata> shows = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadata(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadata_ShowIdsWithMetadata_ArgumentExceptions()
        {
            List<ShowIdsWithMetadata> showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadata(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadataAndCollectedAt_CollectedShowWithMetadata_ArgumentExceptions()
        {
            List<CollectedShowWithMetadata> shows = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadataCollectedAt(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsWithMetadataAndCollectedAt_CollectedShowIdsWithMetadata_ArgumentExceptions()
        {
            List<CollectedShowIdsWithMetadata> showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsWithMetadataCollectedAt(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
