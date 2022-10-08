namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            ShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            ShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowsAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            List<ShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithShowsAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
