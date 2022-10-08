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
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(show, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(showIds, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_WatchedShow_ArgumentExceptions()
        {
            WatchedShow show = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowWatchedAt_WatchedShowIds_ArgumentExceptions()
        {
            WatchedShowIds showIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowWatchedAt(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsWatchedAt_WatchedShow_ArgumentExceptions()
        {
            List<WatchedShow> shows = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowsWatchedAt(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithShowsWatchedAt_WatchedShowIds_ArgumentExceptions()
        {
            List<WatchedShowIds> showsIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithShowsWatchedAt(showsIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
