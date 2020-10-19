namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder.Interfaces;
    using TraktNet.Objects.Post.Users.CustomListItems;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_UserCustomListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_UserCustomListItemsPostBuilder()
        {
            ITraktUserCustomListItemsPostBuilder syncCollectionPostBuilder = TraktPost.NewUserCustomListItemsPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_UserCustomListItemsPostBuilder_Empty_Build()
        {
            ITraktUserCustomListItemsPost userCustomListItemsPost = TraktPost.NewUserCustomListItemsPost().Build();
            userCustomListItemsPost.Should().NotBeNull();
            userCustomListItemsPost.Movies.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.Shows.Should().NotBeNull().And.BeEmpty();
            userCustomListItemsPost.People.Should().NotBeNull().And.BeEmpty();
        }
    }
}
