namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("Objects.Post.Comments.Implementations")]
    public class TraktShowCommentPost_Tests
    {
        [Fact]
        public void Test_TraktShowCommentPost_Validate()
        {
            ITraktShowCommentPost showCommentPost = new TraktShowCommentPost();

            // Comment = null
            Action act = () => showCommentPost.Validate();
            act.Should().Throw<ArgumentNullException>();

            // Comment = less than five words
            showCommentPost.Comment = "one two three four";
            act.Should().Throw<ArgumentOutOfRangeException>();

            // Show = null
            showCommentPost.Comment = "one two three four five";
            act.Should().Throw<ArgumentNullException>();

            // Show Ids = null
            showCommentPost.Show = new TraktShow();
            act.Should().Throw<ArgumentNullException>();

            // Show IDs have no valid id
            showCommentPost.Show = new TraktShow
            {
                Ids = new TraktShowIds()
            };
            act.Should().Throw<ArgumentException>();

            // valid
            showCommentPost.Show = new TraktShow
            {
                Ids = new TraktShowIds { Trakt = 1 }
            };
            act.Should().NotThrow();
        }
    }
}
