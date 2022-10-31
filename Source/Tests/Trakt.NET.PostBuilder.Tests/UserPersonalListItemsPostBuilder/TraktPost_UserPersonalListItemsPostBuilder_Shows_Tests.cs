namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShow_ITraktShow()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShow_ITraktShowIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotes_ITraktShow()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES)
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotes_ITraktShowIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES)
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotes_ShowWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotes(new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1,
                                                           TraktPost_Tests_Common_Data.NOTES))
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowWithNotes_ShowIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowWithNotes(new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1,
                                                              TraktPost_Tests_Common_Data.NOTES))
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

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShows_ITraktShow()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShows_ITraktShowIds()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().BeNull();

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsWithNotes_ShowWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsWithNotes(new List<ShowWithNotes>
                {
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowWithNotes(TraktPost_Tests_Common_Data.SHOW_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_WithShowsWithNotes_ShowIdsWithNotes()
        {
            ITraktUserPersonalListItemsPost userPersonalListItemsPost = TraktPost.NewUserPersonalListItemsPost()
                .WithShowsWithNotes(new List<ShowIdsWithNotes>
                {
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_1, TraktPost_Tests_Common_Data.NOTES),
                    new ShowIdsWithNotes(TraktPost_Tests_Common_Data.SHOW_IDS_2, TraktPost_Tests_Common_Data.NOTES)
                })
                .Build();

            userPersonalListItemsPost.Should().NotBeNull();
            userPersonalListItemsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsPost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsPost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().Be(TraktPost_Tests_Common_Data.NOTES);

            userPersonalListItemsPost.Movies.Should().BeNull();
            userPersonalListItemsPost.Seasons.Should().BeNull();
            userPersonalListItemsPost.Episodes.Should().BeNull();
            userPersonalListItemsPost.People.Should().BeNull();
        }
    }
}
