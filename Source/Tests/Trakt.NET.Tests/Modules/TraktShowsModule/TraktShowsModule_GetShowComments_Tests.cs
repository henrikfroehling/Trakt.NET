namespace TraktNet.Tests.Modules.TraktShowsModule
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

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_COMMENTS_URI = $"shows/{SHOW_ID}/comments";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_COMMENTS_URI,
                SHOW_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                SHOW_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, COMMENT_SORT_ORDER);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}?page={PAGE}",
                SHOW_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                SHOW_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}?limit={LIMIT}",
                SHOW_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIMIT}",
                SHOW_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}?page={PAGE}&limit={LIMIT}",
                SHOW_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                SHOW_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Shows.GetShowCommentsAsync(SHOW_ID, COMMENT_SORT_ORDER, pagedParameters);

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
        public void Test_TraktShowsModule_GetShowComments_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_COMMENTS_URI,
                SHOW_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Shows.GetShowCommentsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowCommentsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowCommentsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
