namespace TraktNet.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string LIKE_COMMENT_URI = $"comments/{COMMENT_ID}/like";

        [Fact]
        public async Task Test_TraktCommentsModule_LikeComment()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Comments.LikeCommentAsync(COMMENT_ID);
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.NotFound);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.Conflict);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)412);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)422);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)429);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)503);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)504);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)520);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)521);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, (HttpStatusCode)522);
            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_LikeComment_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(LIKE_COMMENT_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Comments.LikeCommentAsync(0);
            act.Should().Throw<ArgumentException>();
        }
    }
}
