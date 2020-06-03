namespace TraktNet.Modules.Tests.TraktUsersModule
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

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_LIST_COMMENTS_URI = $"users/{USERNAME}/lists/{LIST_ID}/comments";

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetListCommentsAsync(USERNAME, LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                LIST_COMMENTS_JSON, PAGE, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, 1, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetListComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIST_COMMENTS_LIMIT}",
                LIST_COMMENTS_JSON, PAGE, LIST_COMMENTS_LIMIT, 1, LIST_COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIST_COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetListCommentsAsync(USERNAME, LIST_ID, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIST_COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktListNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_COMMENTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(USERNAME, LIST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetListComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_LIST_COMMENTS_URI,
                LIST_COMMENTS_JSON, 1, 10, 1, LIST_COMMENTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Users.GetListCommentsAsync(null, LIST_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(string.Empty, LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetListCommentsAsync("user name", LIST_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetListCommentsAsync(USERNAME, "list id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
