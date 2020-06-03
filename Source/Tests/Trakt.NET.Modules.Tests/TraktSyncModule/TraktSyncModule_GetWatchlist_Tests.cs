namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_WATCHLIST_URI = "sync/watchlist";

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_WATCHLIST_URI,
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response = await client.Sync.GetWatchlistAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}",
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHLIST_JSON, PAGE, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}?page={PAGE}&limit={LIMIT}",
                WATCHLIST_JSON, PAGE, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHLIST_JSON, PAGE, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(WATCHLIST_SORT_BY);
            response.SortHow.Should().NotBeNull().And.Be(WATCHLIST_SORT_HOW);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlist_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act = () => client.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
