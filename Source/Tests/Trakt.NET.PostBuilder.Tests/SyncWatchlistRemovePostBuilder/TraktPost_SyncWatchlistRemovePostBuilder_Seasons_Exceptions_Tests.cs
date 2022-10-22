namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncWatchlistRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncWatchlistRemovePost> act = () => TraktPost.NewSyncWatchlistRemovePost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncWatchlistRemovePost> act = () => TraktPost.NewSyncWatchlistRemovePost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktSyncWatchlistRemovePost> act = () => TraktPost.NewSyncWatchlistRemovePost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktSyncWatchlistRemovePost> act = () => TraktPost.NewSyncWatchlistRemovePost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
