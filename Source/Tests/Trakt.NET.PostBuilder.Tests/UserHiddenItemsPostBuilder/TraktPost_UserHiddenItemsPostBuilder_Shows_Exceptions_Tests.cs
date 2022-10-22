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
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
