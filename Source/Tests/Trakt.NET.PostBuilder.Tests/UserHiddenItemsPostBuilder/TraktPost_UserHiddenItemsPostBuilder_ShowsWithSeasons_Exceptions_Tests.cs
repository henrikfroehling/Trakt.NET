namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShow_Seasons_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(show, new List<int>())
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_1, default(List<int>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShowIds_Seasons_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(showIds, new List<int>())
                .Build();

            act.Should().Throw<ArgumentNullException>();

            act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(TraktPost_Tests_Common_Data.SHOW_IDS_1, default(List<int>))
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShow_Seasons_Params_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(show, 1, 2, 3)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_ITraktShowIds_Seasons_Params_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(showIds, 1, 2, 3)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowWithSeasons_ArgumentExceptions()
        {
            HiddenShowWithSeasons showWithSeasons = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(showWithSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowAndSeasons_HiddenShowIdsWithSeasons_ArgumentExceptions()
        {
            HiddenShowIdsWithSeasons showIdsWithSeasons = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowAndSeasons(showIdsWithSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowWithSeasons_ArgumentExceptions()
        {
            List<HiddenShowWithSeasons> showsWithSeasons = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(showsWithSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShowsAndSeasons_HiddenShowIdsWithSeasons_ArgumentExceptions()
        {
            List<HiddenShowIdsWithSeasons> showIdsWithSeasons = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShowsAndSeasons(showIdsWithSeasons)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
