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
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            ShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            ShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowsAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            List<ShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_WithShowsAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
