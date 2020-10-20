namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_UserHiddenItemsPostBuilder()
        {
            ITraktUserHiddenItemsPostBuilder syncCollectionPostBuilder = TraktPost.NewUserHiddenItemsPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_Empty_Build()
        {
            ITraktUserHiddenItemsPost userHiddenItemsPost = TraktPost.NewUserHiddenItemsPost().Build();
            userHiddenItemsPost.Should().NotBeNull();
            userHiddenItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userHiddenItemsPost.Seasons.Should().NotBeNull().And.BeEmpty();
        }
    }
}
