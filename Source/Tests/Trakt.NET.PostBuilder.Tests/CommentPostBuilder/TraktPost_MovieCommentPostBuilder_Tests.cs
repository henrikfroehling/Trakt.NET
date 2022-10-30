namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_MovieCommentPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_Empty_Build()
        {
            Func<ITraktMovieCommentPost> act = () => TraktPost.NewMovieCommentPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_Comment_Movie()
        {
            ITraktMovieCommentPost movieCommentPost = TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .Build();

            movieCommentPost.Should().NotBeNull();
            movieCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            movieCommentPost.Movie.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCommentPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCommentPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCommentPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCommentPost.Sharing.Should().BeNull();
            movieCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_Comment_Movie_Sharing()
        {
            ITraktMovieCommentPost movieCommentPost = TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .Build();

            movieCommentPost.Should().NotBeNull();
            movieCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            movieCommentPost.Movie.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCommentPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCommentPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCommentPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCommentPost.Sharing.Should().NotBeNull();
            movieCommentPost.Sharing.Apple.Should().BeTrue();
            movieCommentPost.Sharing.Facebook.Should().BeTrue();
            movieCommentPost.Sharing.Google.Should().BeTrue();
            movieCommentPost.Sharing.Medium.Should().BeTrue();
            movieCommentPost.Sharing.Slack.Should().BeTrue();
            movieCommentPost.Sharing.Tumblr.Should().BeTrue();
            movieCommentPost.Sharing.Twitter.Should().BeTrue();
            movieCommentPost.Spoiler.Should().BeNull();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_Comment_Movie_Spoiler()
        {
            ITraktMovieCommentPost movieCommentPost = TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithSpoiler(true)
                .Build();

            movieCommentPost.Should().NotBeNull();
            movieCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            movieCommentPost.Movie.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCommentPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCommentPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCommentPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCommentPost.Sharing.Should().BeNull();
            movieCommentPost.Spoiler.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktPost_MovieCommentPostBuilder_Complete()
        {
            ITraktMovieCommentPost movieCommentPost = TraktPost.NewMovieCommentPost()
                .WithComment(TraktPost_Tests_Common_Data.VALID_COMMENT)
                .WithMovie(TraktPost_Tests_Common_Data.MOVIE_1)
                .WithSharing(TraktPost_Tests_Common_Data.SHARING)
                .WithSpoiler(true)
                .Build();

            movieCommentPost.Should().NotBeNull();
            movieCommentPost.Comment.Should().Be(TraktPost_Tests_Common_Data.VALID_COMMENT);
            movieCommentPost.Movie.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Should().NotBeNull();
            movieCommentPost.Movie.Ids.Trakt.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Trakt);
            movieCommentPost.Movie.Ids.Slug.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Slug);
            movieCommentPost.Movie.Ids.Imdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Imdb);
            movieCommentPost.Movie.Ids.Tmdb.Should().Be(TraktPost_Tests_Common_Data.MOVIE_1.Ids.Tmdb);
            movieCommentPost.Sharing.Should().NotBeNull();
            movieCommentPost.Sharing.Apple.Should().BeTrue();
            movieCommentPost.Sharing.Facebook.Should().BeTrue();
            movieCommentPost.Sharing.Google.Should().BeTrue();
            movieCommentPost.Sharing.Medium.Should().BeTrue();
            movieCommentPost.Sharing.Slack.Should().BeTrue();
            movieCommentPost.Sharing.Tumblr.Should().BeTrue();
            movieCommentPost.Sharing.Twitter.Should().BeTrue();
            movieCommentPost.Spoiler.Should().BeTrue();
        }
    }
}
