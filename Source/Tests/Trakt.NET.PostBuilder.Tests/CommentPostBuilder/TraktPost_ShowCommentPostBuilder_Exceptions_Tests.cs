namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_ShowCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithComment_ArgumentNullException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(null)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithComment_ArgumentOutOfRangeException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.INVALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithShow_Show_ArgumentNullException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithShow_ShowIds_ArgumentNullException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(new TraktShow())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithShow_ShowIds_ArgumentException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(new TraktShow { Ids = new TraktShowIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_ShowCommentPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktShowCommentPost> act = () => TraktPost.NewShowCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithShow(TraktPost_Tests_Common_Data.SHOW_1)
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
