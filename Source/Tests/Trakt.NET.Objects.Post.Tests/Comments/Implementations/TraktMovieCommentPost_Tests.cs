namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("Objects.Post.Comments.Implementations")]
    public class TraktMovieCommentPost_Tests
    {
        [Fact]
        public void Test_TraktMovieCommentPost_Validate()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost();

            // Comment = null
            Action act = () => movieCommentPost.Validate();
            act.Should().Throw<ArgumentNullException>();

            // Comment = less than five words
            movieCommentPost.Comment = "one two three four";
            act.Should().Throw<ArgumentOutOfRangeException>();

            // Movie = null
            movieCommentPost.Comment = "one two three four five";
            act.Should().Throw<ArgumentNullException>();

            // valid
            movieCommentPost.Movie = new TraktMovie();
            act.Should().NotThrow();
        }
    }
}
