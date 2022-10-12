namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeason_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeason(season)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeason_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeason(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_ITraktSeason_ArgumentExceptions()
        {
            ITraktSeason season = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(season, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_ITraktSeasonIds_ArgumentExceptions()
        {
            ITraktSeasonIds seasonIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonIds, TraktPost_Tests_Common_Data.NOTES)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_SeasonWithNotes_ArgumentExceptions()
        {
            SeasonWithNotes seasonWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonWithNotes = new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonWithNotes = new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonWithNotes_SeasonIdsWithNotes_ArgumentExceptions()
        {
            SeasonIdsWithNotes seasonIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, null);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES_TOO_LONG);

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasons_ITraktSeason_ArgumentExceptions()
        {
            List<ITraktSeason> seasons = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasons(seasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasons_ITraktSeasonIds_ArgumentExceptions()
        {
            List<ITraktSeasonIds> seasonIds = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasons(seasonIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonsWithNotes_SeasonWithNotes_ArgumentExceptions()
        {
            List<SeasonWithNotes> seasonsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonsWithNotes = new List<SeasonWithNotes>
            {
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonsWithNotes = new List<SeasonWithNotes>
            {
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonWithNotes(TraktPost_Tests_Common_Data.SEASON_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithSeasonsWithNotes_SeasonIdsWithNotes_ArgumentExceptions()
        {
            List<SeasonIdsWithNotes> seasonIdsWithNotes = null;

            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new List<SeasonIdsWithNotes>
            {
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, null)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            seasonIdsWithNotes = new List<SeasonIdsWithNotes>
            {
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                new SeasonIdsWithNotes(TraktPost_Tests_Common_Data.SEASON_IDS_2, TraktPost_Tests_Common_Data.NOTES_TOO_LONG)
            };

            act = () => TraktPost.NewUserPersonalListItemsPost()
                .WithSeasonsWithNotes(seasonIdsWithNotes)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
