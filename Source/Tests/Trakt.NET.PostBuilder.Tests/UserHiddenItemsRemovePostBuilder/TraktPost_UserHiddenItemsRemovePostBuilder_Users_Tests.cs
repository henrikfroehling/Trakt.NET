namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System.Linq;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUser_ITraktUser()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithUser(TraktPost_Tests_Common_Data.USER_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Users.Should().NotBeNull().And.HaveCount(1);

            ITraktUser postUser = userHiddenItemsRemovePost.Users.ToArray()[0];
            postUser.Ids.Should().NotBeNull();
            postUser.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.Slug);
            postUser.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.UUID);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUser_ITraktUserIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithUser(TraktPost_Tests_Common_Data.USER_IDS_1)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Users.Should().NotBeNull().And.HaveCount(1);

            ITraktUser postUser = userHiddenItemsRemovePost.Users.ToArray()[0];
            postUser.Ids.Should().NotBeNull();
            postUser.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.Slug);
            postUser.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.UUID);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUsers_ITraktUser()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithUsers(TraktPost_Tests_Common_Data.USERS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Users.Should().NotBeNull().And.HaveCount(2);

            ITraktUser postUser1 = userHiddenItemsRemovePost.Users.ToArray()[0];
            postUser1.Ids.Should().NotBeNull();
            postUser1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.Slug);
            postUser1.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_1.Ids.UUID);

            ITraktUser postUser2 = userHiddenItemsRemovePost.Users.ToArray()[1];
            postUser2.Ids.Should().NotBeNull();
            postUser2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_2.Ids.Slug);
            postUser2.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_2.Ids.UUID);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_WithUsers_ITraktUserIds()
        {
            ITraktUserHiddenItemsRemovePost userHiddenItemsRemovePost = TraktPost.NewUserHiddenItemsRemovePost()
                .WithUsers(TraktPost_Tests_Common_Data.USER_IDS)
                .Build();

            userHiddenItemsRemovePost.Should().NotBeNull();
            userHiddenItemsRemovePost.Users.Should().NotBeNull().And.HaveCount(2);

            ITraktUser postUser1 = userHiddenItemsRemovePost.Users.ToArray()[0];
            postUser1.Ids.Should().NotBeNull();
            postUser1.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.Slug);
            postUser1.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_1.UUID);

            ITraktUser postUser2 = userHiddenItemsRemovePost.Users.ToArray()[1];
            postUser2.Ids.Should().NotBeNull();
            postUser2.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_2.Slug);
            postUser2.Ids.UUID.Should().Be(TraktPost_Tests_Common_Data.USER_IDS_2.UUID);

            userHiddenItemsRemovePost.Movies.Should().BeNull();
            userHiddenItemsRemovePost.Shows.Should().BeNull();
            userHiddenItemsRemovePost.Seasons.Should().BeNull();
        }
    }
}
