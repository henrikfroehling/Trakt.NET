﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShow_Seasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SEASON_NUMBERS_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShowIds_Seasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SEASON_NUMBERS_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShow_Seasons_Params()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, 1, 2, 3)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShowIds_Seasons_Params()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, 1, 2, 3)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowWithSeasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_1,
                                                              TraktPost_Tests_Common_Data.SEASON_NUMBERS_1))
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowIdsWithSeasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                                 TraktPost_Tests_Common_Data.SEASON_NUMBERS_1))
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowWithSeasons_Params()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_1, 1, 2, 3))
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowIdsWithSeasons_Params()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, 1, 2, 3))
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsPost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowWithSeasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(new List<HiddenShowWithSeasons>
                {
                    new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SEASON_NUMBERS_1),
                    new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.SEASON_NUMBERS_2)
                })
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_2.Count);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowIdsWithSeasons()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(new List<HiddenShowIdsWithSeasons>
                {
                    new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SEASON_NUMBERS_1),
                    new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.SEASON_NUMBERS_2)
                })
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_2.Count);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowWithSeasons_Mixed()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(new List<HiddenShowWithSeasons>
                {
                    new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SEASON_NUMBERS_1),
                    new HiddenShowWithSeasons(TraktPost_Tests_Common_Data.SHOW_2, 1, 2)
                })
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsPost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_1.Count);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsPost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowIdsWithSeasons_Mixed()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(new List<HiddenShowIdsWithSeasons>
                {
                    new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, 1, 2, 3),
                    new HiddenShowIdsWithSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.SEASON_NUMBERS_2)
                })
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsPost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(3);

            ITraktUserHiddenItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[2].Number.Should().Be(3);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsPost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(TraktPost_Tests_Common_Data.SEASON_NUMBERS_2.Count);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[1].Number.Should().Be(2);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
            userHiddenItemsPost.Users.Should().BeNull();
        }
    }
}
