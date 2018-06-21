namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHLIST_URI = $"users/{USERNAME}/watchlist";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_WATCHLIST_URI,
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response = await client.Users.GetWatchlistAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_WATCHLIST_URI,
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktWatchlistItem> response = await client.Users.GetWatchlistAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, 1, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, 1, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, PAGE, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, 1, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}?page={PAGE}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, PAGE, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlist_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, PAGE, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(WATCHLIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(WATCHLIST_ITEM_COUNT);
            response.Limit.Should().Be(WATCHLIST_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(SORT_HOW);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlist_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_WATCHLIST_URI,
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Users.GetWatchlistAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetWatchlistAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetWatchlistAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
