namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowAndSeasons_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(show, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowAndSeasons_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(showIds, TraktPost_Tests_Common_Data.SHOW_SEASONS_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowAndSeasons_ShowAndSeasons_ArgumentExceptions()
        {
            ShowAndSeasons showAndSeasons = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(showAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowAndSeasons_ShowIdsAndSeasons_ArgumentExceptions()
        {
            ShowIdsAndSeasons showIdsAndSeasons = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowsAndSeasons_ShowAndSeasons_ArgumentExceptions()
        {
            List<ShowAndSeasons> showsAndSeasons = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowsAndSeasons(showsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_WithShowsAndSeasons_ShowIdsAndSeasons_ArgumentExceptions()
        {
            List<ShowIdsAndSeasons> showIdsAndSeasons = null;

            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost()
                .WithShowsAndSeasons(showIdsAndSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
