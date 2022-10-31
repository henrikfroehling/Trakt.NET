namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(season, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_SeasonWithNotes_ArgumentExceptions()
        {
            SeasonWithNotes seasonWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonWithNotes = new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonWithNotes = new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonWithNotes_SeasonIdsWithNotes_ArgumentExceptions()
        {
            SeasonIdsWithNotes seasonIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, null);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonsWithNotes_SeasonWithNotes_ArgumentExceptions()
        {
            List<SeasonWithNotes> seasonsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonsWithNotes = new List<SeasonWithNotes>
            {
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonsWithNotes = new List<SeasonWithNotes>
            {
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_SyncWatchlistPostBuilder_WithSeasonsWithNotes_SeasonIdsWithNotes_ArgumentExceptions()
        {
            List<SeasonIdsWithNotes> seasonIdsWithNotes = null;

            Func<ITraktSyncWatchlistPost> act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new List<SeasonIdsWithNotes>
            {
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, null)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new List<SeasonIdsWithNotes>
            {
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewSyncWatchlistPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
