namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.COLLECTION_SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_CollectionShowAndSeasons_ArgumentExceptions()
        {
            CollectionShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowAndSeasons_CollectionShowIdsAndSeasons_ArgumentExceptions()
        {
            CollectionShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndSeasons_CollectionShowAndSeasons_ArgumentExceptions()
        {
            List<CollectionShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_WithShowsAndSeasons_CollectionShowIdsAndSeasons_ArgumentExceptions()
        {
            List<CollectionShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
