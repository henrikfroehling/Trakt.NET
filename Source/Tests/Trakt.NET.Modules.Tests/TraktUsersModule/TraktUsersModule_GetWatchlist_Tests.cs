namespace TraktNet.Modules.Tests.TraktUsersModule
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

    [TestCategory("Modules.Users")]
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
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_Sort()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER);

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
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_Sort_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO);

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
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_Sort_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?page={PAGE}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, null, pagedParameters);

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
        public async Task Test_TraktUsersModule_GetWatchlist_With_Type_And_Sort_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, 1, 10, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, null, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO);

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
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, EXTENDED_INFO);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, null, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, null, pagedParameters);

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
                await client.Users.GetWatchlistAsync(USERNAME, null, null, null, pagedParameters);

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
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={WATCHLIST_LIMIT}",
                WATCHLIST_JSON, PAGE, WATCHLIST_LIMIT, 1, WATCHLIST_ITEM_COUNT,
                sortBy: SORT_BY, sortHow: SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, WATCHLIST_LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Users.GetWatchlistAsync(USERNAME, WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO, pagedParameters);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
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
        public async Task Test_TraktUsersModule_GetWatchlist_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_URI, statusCode);

            try
            {
                await client.Users.GetWatchlistAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
