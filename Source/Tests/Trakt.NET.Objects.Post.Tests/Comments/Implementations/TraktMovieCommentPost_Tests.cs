namespace TraktNet.Objects.Post.Tests.Comments.Implementations
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
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
            act.Should().Throw<TraktPostValidationException>();

            // Comment = less than five words
            movieCommentPost.Comment = "one two three four";
            act.Should().Throw<TraktPostValidationException>();

            // Movie = null
            movieCommentPost.Comment = "one two three four five";
            act.Should().Throw<TraktPostValidationException>();

            // Movie Ids = null
            movieCommentPost.Movie = new TraktMovie();
            act.Should().Throw<TraktPostValidationException>();

            // Movie IDs have no valid id
            movieCommentPost.Movie = new TraktMovie
            {
                Ids = new TraktMovieIds()
            };
            act.Should().Throw<TraktPostValidationException>();

            // valid
            movieCommentPost.Movie = new TraktMovie
            {
                Ids = new TraktMovieIds { Trakt = 1 }
            };
            act.Should().NotThrow();
        }
    }
}
