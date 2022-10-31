namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShow_ITraktShow_ArgumentExceptions()
        {
            ITraktShow show = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithShow(show)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShow_ITraktShowIds_ArgumentExceptions()
        {
            ITraktShowIds showIds = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithShow(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShows_ITraktShow_ArgumentExceptions()
        {
            List<ITraktShow> shows = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithShows(shows)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithShows_ITraktShowIds_ArgumentExceptions()
        {
            List<ITraktShowIds> showIds = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithShows(showIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
