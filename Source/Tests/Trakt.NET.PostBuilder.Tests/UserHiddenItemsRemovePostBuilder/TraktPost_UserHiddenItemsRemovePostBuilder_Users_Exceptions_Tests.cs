namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUser_ITraktUser_ArgumentExceptions()
        {
            ITraktUser user = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithUser(user)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUser_ITraktUserIds_ArgumentExceptions()
        {
            ITraktUserIds userIds = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithUser(userIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUsers_ITraktUser_ArgumentExceptions()
        {
            List<ITraktUser> users = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithUsers(users)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUsers_ITraktUserIds_ArgumentExceptions()
        {
            List<ITraktUserIds> userIds = null;

            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost()
                .WithUsers(userIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
