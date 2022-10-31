namespace TraktNet.Modules.Tests.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string UNLIKE_COMMENT_URI = $"comments/{COMMENT_ID}/like";

        [Fact]
        public async Task Test_TraktCommentsModule_UnlikeComment()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_COMMENT_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Comments.UnlikeCommentAsync(COMMENT_ID);
            response.IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktCommentNotFoundException))]
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
        public async Task Test_TraktCommentsModule_UnlikeComment_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_COMMENT_URI, statusCode);

            try
            {
                await client.Comments.UnlikeCommentAsync(COMMENT_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktCommentsModule_UnlikeComment_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(UNLIKE_COMMENT_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Comments.UnlikeCommentAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
