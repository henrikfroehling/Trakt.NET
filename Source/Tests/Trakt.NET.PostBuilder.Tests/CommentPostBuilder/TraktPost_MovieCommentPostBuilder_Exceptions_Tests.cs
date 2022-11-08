namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_MovieCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithComment_ArgumentNullException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(null)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithComment_ArgumentOutOfRangeException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.INVALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithMovie_Movie_ArgumentNullException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithMovie_MovieIds_ArgumentNullException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(new TraktMovie())
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithMovie_MovieIds_ArgumentException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(new TraktMovie { Ids = new TraktMovieIds() })
                .Build();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_WithSharing_ArgumentNullException()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithSharing(null)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
