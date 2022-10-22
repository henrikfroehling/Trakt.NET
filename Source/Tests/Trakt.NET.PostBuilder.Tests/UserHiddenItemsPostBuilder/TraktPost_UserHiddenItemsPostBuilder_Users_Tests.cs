namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUser_ITraktUser()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUser(TraktPost_Tests_Common_Data.USER_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(1);

            ITraktUser postUser = userHiddenItemsPost.Users.ToArray()[0];
            postUser.Ids.Should().NotBeNull();
            postUser.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.Slug);
            postUser.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.UUID);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUser_ITraktUserIds()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUser(TraktPost_Tests_Common_Data.USER_IDS_1)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(1);

            ITraktUser postUser = userHiddenItemsPost.Users.ToArray()[0];
            postUser.Ids.Should().NotBeNull();
            postUser.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.Slug);
            postUser.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.UUID);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUsers_ITraktUser()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUsers(TraktPost_Tests_Common_Data.USERS)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(2);

            ITraktUser postUser1 = userHiddenItemsPost.Users.ToArray()[0];
            postUser1.Ids.Should().NotBeNull();
            postUser1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.Slug);
            postUser1.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.UUID);

            ITraktUser postUser2 = userHiddenItemsPost.Users.ToArray()[1];
            postUser2.Ids.Should().NotBeNull();
            postUser2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_2.Ids.Slug);
            postUser2.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_2.Ids.UUID);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_WithUsers_ITraktUserIds()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost()
                .WithUsers(TraktPost_Tests_Common_Data.USER_IDS)
                .Build();

            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Users.Should().NotBeNull().And.HaveCount(2);

            ITraktUser postUser1 = userHiddenItemsPost.Users.ToArray()[0];
            postUser1.Ids.Should().NotBeNull();
            postUser1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.Slug);
            postUser1.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.UUID);

            ITraktUser postUser2 = userHiddenItemsPost.Users.ToArray()[1];
            postUser2.Ids.Should().NotBeNull();
            postUser2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_2.Slug);
            postUser2.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_2.UUID);

            userHiddenItemsPost.Movies.Should().BeNull();
            userHiddenItemsPost.Shows.Should().BeNull();
            userHiddenItemsPost.Seasons.Should().BeNull();
        }
    }
}
