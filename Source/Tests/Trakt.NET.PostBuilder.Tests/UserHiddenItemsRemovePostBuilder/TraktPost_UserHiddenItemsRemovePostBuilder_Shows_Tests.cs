﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShow_ITraktShow()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShow_ITraktShowIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithShow(TraktPost_Tests_Common_Data.SHOW_IDS_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(1);

            ITraktUserHiddenItemsPostShow postShow = userHiddenItemsRemovePost.Shows.ToArray()[0];
            postShow.Title.Should().BeNull();
            postShow.Year.Should().BeNull();
            postShow.Ids.Should().NotBeNull();
            postShow.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShows_ITraktShow()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOWS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsRemovePost.Shows.ToArray()[0];
            postShow1.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Title);
            postShow1.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Year);
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_1.Ids.Tmdb);

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsRemovePost.Shows.ToArray()[1];
            postShow2.Title.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Title);
            postShow2.Year.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Year);
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_2.Ids.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShows_ITraktShowIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithShows(TraktPost_Tests_Common_Data.SHOW_IDS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktUserHiddenItemsPostShow postShow1 = userHiddenItemsRemovePost.Shows.ToArray()[0];
            postShow1.Title.Should().BeNull();
            postShow1.Year.Should().BeNull();
            postShow1.Ids.Should().NotBeNull();
            postShow1.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Trakt);
            postShow1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Slug);
            postShow1.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Imdb);
            postShow1.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_1.Tmdb);

            ITraktUserHiddenItemsPostShow postShow2 = userHiddenItemsRemovePost.Shows.ToArray()[1];
            postShow2.Title.Should().BeNull();
            postShow2.Year.Should().BeNull();
            postShow2.Ids.Should().NotBeNull();
            postShow2.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Trakt);
            postShow2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Slug);
            postShow2.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Imdb);
            postShow2.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.SHOW_IDS_2.Tmdb);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
            userHiddenItemsRemovePost.Users.Should().BeNull();
        }
    }
}
