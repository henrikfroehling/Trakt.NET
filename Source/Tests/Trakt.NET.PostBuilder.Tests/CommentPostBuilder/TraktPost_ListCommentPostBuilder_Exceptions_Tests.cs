namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_ListCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithComment_ArgumentNullException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(null)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithComment_ArgumentOutOfRangeException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.INVALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithList_List_ArgumentNullException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithList_ListIds_ArgumentNullException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(new TraktList())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithList_ListIds_ArgumentException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(new TraktList { Ids = new TraktListIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_ListCommentPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktListCommentPost> act = () => TraktPost.NewListCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithList(TraktPost_Tests_Common_Data.LIST)
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
