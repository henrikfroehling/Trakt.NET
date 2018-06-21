namespace TraktNet.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Comments;
    using TraktNet.Objects.Post.Comments.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string POST_COMMENT_REPLY_URI = $"comments/{COMMENT_ID}/replies";

        [Fact]
        public async Task Test_TraktCommentsModule_PostCommentReply()
        {
            ITraktCommentReplyPost commentReplyPost = new TraktCommentReplyPost
            {
                Comment = COMMENT_TEXT
            };

            string postJson = await TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);

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
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostCommentReply_With_Spoiler()
        {
            ITraktCommentReplyPost commentReplyPost = new TraktCommentReplyPost
            {
                Comment = COMMENT_TEXT,
                Spoiler = SPOILER
            };

            string postJson = await TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, postJson, COMMENT_POST_RESPONSE_JSON);
            TraktResponse<ITraktCommentPostResponse> response = await client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT, SPOILER);

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
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Sharing.Medium.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_PostCommentReply_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, COMMENT_TEXT);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktCommentsModule_PostCommentReply_ArgumentExceptions()
        {
            ITraktCommentReplyPost commentReplyPost = new TraktCommentReplyPost
            {
                Comment = COMMENT_TEXT
            };

            string postJson = await TestUtility.SerializeObject(commentReplyPost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(POST_COMMENT_REPLY_URI, postJson, COMMENT_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktCommentPostResponse>>> act = () => client.Comments.PostCommentReplyAsync(0, COMMENT_TEXT);
            act.Should().Throw<ArgumentException>();

            act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, string.Empty);
            act.Should().Throw<ArgumentException>();

            const string comment = "one two three four";

            act = () => client.Comments.PostCommentReplyAsync(COMMENT_ID, comment);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
