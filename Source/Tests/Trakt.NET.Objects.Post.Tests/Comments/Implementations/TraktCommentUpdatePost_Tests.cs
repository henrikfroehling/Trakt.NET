namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("Objects.Post.Comments.Implementations")]
    public class TraktCommentUpdatePost_Tests
    {
        [Fact]
        public void Test_TraktCommentUpdatePost_Validate()
        {
            ITraktCommentUpdatePost commentUpdatePost = new TraktCommentUpdatePost();

            // Comment = null
            Action act = () => commentUpdatePost.Validate();
            act.Should().Throw<TraktPostValidationException>();

            // Comment = less than five words
            commentUpdatePost.Comment = "one two three four";
            act.Should().Throw<TraktPostValidationException>();

            // valid
            commentUpdatePost.Comment = "one two three four five";
            act.Should().NotThrow();
        }
    }
}
