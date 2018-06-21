namespace TraktNet.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Comments")]
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

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(GET_COMMENT_REPLIES_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentReplies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_REPLIES_URI,
                                                           COMMENT_REPLIES_JSON, 1, 10, COMMENT_REPLIES_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Comments.GetCommentRepliesAsync(0);
            act.Should().Throw<ArgumentException>();
        }
    }
}
