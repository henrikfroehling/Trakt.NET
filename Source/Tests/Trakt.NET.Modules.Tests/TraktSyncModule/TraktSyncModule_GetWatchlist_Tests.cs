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
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
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
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_Sort()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}",
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER);

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
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_Sort_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, PAGE, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_Sort_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?page={PAGE}",
                WATCHLIST_JSON, PAGE, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_Sort_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}?limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchlist_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                WATCHLIST_JSON, 1, 10, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO);

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
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, null, EXTENDED_INFO, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, EXTENDED_INFO);

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
                await client.Sync.GetWatchlistAsync(null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, EXTENDED_INFO, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, null, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, null, pagedParameters);

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
                await client.Sync.GetWatchlistAsync(null, null, null, pagedParameters);

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
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHLIST_JSON, PAGE, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
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
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                WATCHLIST_JSON, 2, LIMIT, 5, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                WATCHLIST_JSON, 2, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 1, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                WATCHLIST_JSON, 2, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchlist_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                WATCHLIST_JSON, 1, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktWatchlistItem> response =
                await client.Sync.GetWatchlistAsync(WATCHLIST_ITEM_TYPE, WATCHLIST_SORT_ORDER, EXTENDED_INFO,
                                                    pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_WATCHLIST_URI}/{WATCHLIST_ITEM_TYPE.UriName}/{WATCHLIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                WATCHLIST_JSON, 2, LIMIT, 2, ITEM_COUNT,
                sortBy: WATCHLIST_SORT_BY, sortHow: WATCHLIST_SORT_HOW);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
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
        public async Task Test_TraktSyncModule_GetWatchlist_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHLIST_URI, statusCode);

            try
            {
                await client.Sync.GetWatchlistAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
