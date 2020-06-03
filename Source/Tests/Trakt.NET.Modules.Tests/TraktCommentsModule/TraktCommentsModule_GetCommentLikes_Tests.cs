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

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private readonly string GET_COMMENT_LIKES_URI = $"comments/{GET_COMMENT_ID}/likes";

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI,
                                                           COMMENT_LIKES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?extended={EXTENDED_INFO}",
                                                           COMMENT_LIKES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?page={PAGE}",
                                                           COMMENT_LIKES_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?limit={LIMIT}",
                                                           COMMENT_LIKES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                                                           COMMENT_LIKES_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                                                           COMMENT_LIKES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetCommentLikes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_COMMENT_LIKES_URI}?page={PAGE}&limit={LIMIT}",
                                                           COMMENT_LIKES_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktCommentLike> response = await client.Comments.GetCommentLikesAsync(GET_COMMENT_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktCommentNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(GET_COMMENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetCommentLikes_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENT_LIKES_URI,
                                                           COMMENT_LIKES_JSON, 1, 10, ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktCommentLike>>> act = () => client.Comments.GetCommentLikesAsync(0);
            act.Should().Throw<ArgumentException>();
        }
    }
}
