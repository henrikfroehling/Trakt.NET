namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasons_ITraktShow()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasons_ITraktShowIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasons_ShowAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasons(new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1,
                                                       TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowAndSeasons_ShowIdsAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowAndSeasons(new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                          TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().BeNull();

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotesAndSeasons_ShowWithNotesAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotesAndSeasons(
                    new ShowWithNotesAndSeasons(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1,
                                                                  TraktPost_Tests_Common_Data.NOTES),
                                                TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotesAndSeasons_ShowIdsWithNotesAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotesAndSeasons(
                    new ShowIdsWithNotesAndSeasons(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                                        TraktPost_Tests_Common_Data.NOTES),
                                                   TraktPost_Tests_Common_Data.SHOW_SEASONS_1))
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsAndSeasons_ShowAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsAndSeasons(new List<ShowAndSeasons>
                {
                    new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsAndSeasons_ShowIdsAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsAndSeasons(new List<ShowIdsAndSeasons>
                {
                    new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowIdsAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().BeNull();

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().BeNull();

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsWithNotesAndSeasons_ShowWithNotesAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsWithNotesAndSeasons(new List<ShowWithNotesAndSeasons>
                {
                    new ShowWithNotesAndSeasons(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1,
                                                                  TraktPost_Tests_Common_Data.NOTES),
                                                TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowWithNotesAndSeasons(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2,
                                                                  TraktPost_Tests_Common_Data.NOTES),
                                                TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsWithNotesAndSeasons_ShowIdsWithNotesAndSeasons()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsWithNotesAndSeasons(new List<ShowIdsWithNotesAndSeasons>
                {
                    new ShowIdsWithNotesAndSeasons(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                                        TraktPost_Tests_Common_Data.NOTES),
                                                   TraktPost_Tests_Common_Data.SHOW_SEASONS_1),
                    new ShowIdsWithNotesAndSeasons(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2,
                                                                        TraktPost_Tests_Common_Data.NOTES),
                                                   TraktPost_Tests_Common_Data.SHOW_SEASONS_2)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            // -------------------------------------------------------------------------------
            // Show 1
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow1.Seasons.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShowSeason[] postShowSeasons = postShow1.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShowEpisode[] episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            // -------------------------------------------------------------------------------
            // Show 2
            // -------------------------------------------------------------------------------

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            postShow2.Seasons.Should().NotBeNull().And.HaveCount(2);

            postShowSeasons = postShow2.Seasons.ToArray();

            postShowSeasons[0].Number.Should().Be(1);
            postShowSeasons[0].Episodes.Should().BeNull();

            postShowSeasons[1].Number.Should().Be(2);
            postShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);

            episodes = postShowSeasons[1].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }
    }
}
