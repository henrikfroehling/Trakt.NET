namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRatingsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            ShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            ShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowsAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            List<ShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsRemovePostBuilder_WithShowsAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncRatingsRemovePost> act = () => TraktPost.NewSyncRatingsRemovePost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
