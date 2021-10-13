namespace TraktNet.Modules.Tests.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Post.Comments;
    using TraktNet.Objects.Post.Comments.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private const string POST_MOVIE_COMMENT_URI = "comments";

        [Fact]
        public async Task Test_TraktCommentsModule_PostMovieComment()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Movie = Movie,
                Comment = COMMENT_TEXT
            };

            string postJson = await TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostMovieCommentAsync(Movie, COMMENT_TEXT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(COMMENT_ID);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostMovieComment_With_Spoiler()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Movie = Movie,
                Comment = COMMENT_TEXT,
                Spoiler = SPOILER
            };

            string postJson = await TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostMovieCommentAsync(Movie, COMMENT_TEXT, SPOILER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(COMMENT_ID);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostMovieComment_With_Sharing()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Movie = Movie,
                Comment = COMMENT_TEXT,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostMovieCommentAsync(Movie, COMMENT_TEXT, null, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(COMMENT_ID);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostMovieComment_Complete()
        {
            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Movie = Movie,
                Comment = COMMENT_TEXT,
                Spoiler = SPOILER,
                Sharing = SHARING
            };

            string postJson = await TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostMovieCommentAsync(Movie, COMMENT_TEXT, SPOILER, SHARING);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCommentPostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(COMMENT_ID);
            responseValue.ParentId.Should().Be(0U);
            responseValue.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            responseValue.Comment.Should().Be("Oh, I wasn't really listening.");
            responseValue.Spoiler.Should().BeFalse();
            responseValue.Review.Should().BeFalse();
            responseValue.Replies.Should().Be(0);
            responseValue.Likes.Should().Be(0);
            responseValue.UserRating.Should().NotHaveValue();
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktCommentsModule_PostMovieComment_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, statusCode);

            try
            {
                await client.Comments.PostMovieCommentAsync(Movie, COMMENT_TEXT);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostMovieComment_ArgumentExceptions()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            ITraktMovieCommentPost movieCommentPost = new TraktMovieCommentPost
            {
                Movie = movie,
                Comment = COMMENT_TEXT
            };

            string postJson = await TestUtility.SerializeObject(movieCommentPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_MOVIE_COMMENT_URI, postJson, COMMENT_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostMovieCommentAsync(null, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentNullException>();

            movie.Title = string.Empty;

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            movie.Year = 123;

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            movie.Year = 12345;

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentNullException>();

            movie.Ids = new TraktMovieIds();

            act = () => client.Comments.PostMovieCommentAsync(movie, COMMENT_TEXT);
            await act.Should().ThrowAsync<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = () => client.Comments.PostMovieCommentAsync(movie, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Comments.PostMovieCommentAsync(movie, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            const string comment = "one two three four";

            act = () => client.Comments.PostMovieCommentAsync(movie, comment);
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
