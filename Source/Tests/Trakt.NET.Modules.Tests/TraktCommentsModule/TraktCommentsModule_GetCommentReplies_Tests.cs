namespace TraktNet.Modules.Tests.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string GET_COMMENT_REPLIES_URI = $"comments/{GET_COMMENT_REPLIES_ID}/replies";

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentReplies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI,
                                                           COMMENT_REPLIES_JSON, 1, 10, 1, COMMENT_REPLIES_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENT_REPLIES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENT_REPLIES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentReplies_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_REPLIES_URI}?page={PAGE}",
                                                           COMMENT_REPLIES_JSON, PAGE, 10, 1, COMMENT_REPLIES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENT_REPLIES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENT_REPLIES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentReplies_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_REPLIES_URI}?limit={LIMIT}",
                                                           COMMENT_REPLIES_JSON, 1, LIMIT, 1, COMMENT_REPLIES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENT_REPLIES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENT_REPLIES_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentReplies_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_REPLIES_URI}?page={PAGE}&limit={LIMIT}",
                                                           COMMENT_REPLIES_JSON, PAGE, LIMIT, 1, COMMENT_REPLIES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENT_REPLIES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENT_REPLIES_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
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
        public async Task Test_TraktCommentsModule_GetCommentReplies_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, statusCode);

            try
            {
                await client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
