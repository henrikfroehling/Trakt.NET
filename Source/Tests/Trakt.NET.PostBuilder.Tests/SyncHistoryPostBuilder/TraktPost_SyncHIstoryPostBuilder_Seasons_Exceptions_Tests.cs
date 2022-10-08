namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(season, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(seasonIds, TraktPost_Tests_Common_Data.WATCHED_AT)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_WatchedSeason_ArgumentExceptions()
        {
            WatchedSeason season = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonWatchedAt_WatchedSeasonIds_ArgumentExceptions()
        {
            WatchedSeasonIds seasonIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonWatchedAt(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonsWatchedAt_WatchedSeason_ArgumentExceptions()
        {
            List<WatchedSeason> seasons = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonsWatchedAt(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_WithSeasonsWatchedAt_WatchedSeasonIds_ArgumentExceptions()
        {
            List<WatchedSeasonIds> seasonsIds = null;

            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost()
                .WithSeasonsWatchedAt(seasonsIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
