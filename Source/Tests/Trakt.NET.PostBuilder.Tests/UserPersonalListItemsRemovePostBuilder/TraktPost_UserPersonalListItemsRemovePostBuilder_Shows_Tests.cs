namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShow_ITraktShow()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsRemovePost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShow_ITraktShowIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserPersonalListItemsPostShow postShow = userPersonalListItemsRemovePost.Shows.ToArray()[0];
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShows_ITraktShow()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsRemovePost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsRemovePost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);
            postShow2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShows_ITraktShowIds()
        {
            ITraktUserPersonalListItemsRemovePost userPersonalListItemsRemovePost = TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            userPersonalListItemsRemovePost.Should().NotBeNull();
            userPersonalListItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserPersonalListItemsPostShow postShow1 = userPersonalListItemsRemovePost.Shows.ToArray()[0];
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);
            postShow1.Notes.Should().BeNull();

            ITraktUserPersonalListItemsPostShow postShow2 = userPersonalListItemsRemovePost.Shows.ToArray()[1];
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);
            postShow2.Notes.Should().BeNull();

            userPersonalListItemsRemovePost.Movies.Should().BeNull();
            userPersonalListItemsRemovePost.Seasons.Should().BeNull();
            userPersonalListItemsRemovePost.Episodes.Should().BeNull();
            userPersonalListItemsRemovePost.People.Should().BeNull();
        }
    }
}
