namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("Objects.Post.Comments.Implementations")]
    public class TraktCommentReplyPost_Tests
    {
        [Fact]
        public void Test_TraktCommentReplyPost_Validate()
        {
            ITraktCommentReplyPost commentReplyPost = new TraktCommentReplyPost();

            // Comment = null
            Action act = () => commentReplyPost.Validate();
            act.Should().Throw<ArgumentNullException>();

            // Comment = less than five words
            commentReplyPost.Comment = "one two three four";
            act.Should().Throw<ArgumentOutOfRangeException>();

            // valid
            commentReplyPost.Comment = "one two three four five";
            act.Should().NotThrow();
        }
    }
}
