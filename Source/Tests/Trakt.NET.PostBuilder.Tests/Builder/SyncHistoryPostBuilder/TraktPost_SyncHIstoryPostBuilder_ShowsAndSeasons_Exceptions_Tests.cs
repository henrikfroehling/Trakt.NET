namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.HISTORY_SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            WatchedShowAndSeasons showAndSeasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            WatchedShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsAndSeasons_WatchedShowAndSeasons_ArgumentExceptions()
        {
            List<WatchedShowAndSeasons> showsAndSeasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsAndSeasons_WatchedShowIdsAndSeasons_ArgumentExceptions()
        {
            List<WatchedShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
