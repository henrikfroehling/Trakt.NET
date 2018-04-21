namespace TraktApiSharp.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        [Fact]
        public void Test_TraktSyncModule_GetWatchlist()
        {
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist",
                                                             WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithType()
        {
            const int itemCount = 4;
            var type = TraktSyncItemType.Episode;
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist/{type.UriName}",
                                                             WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithTypeAndExtendedOption()
        {
            const int itemCount = 4;
            var type = TraktSyncItemType.Episode;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist/{type.UriName}?extended={extendedInfo}",
                                                             WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithTypeAndExtendedOptionAndPage()
        {
            const int itemCount = 4;
            var type = TraktSyncItemType.Episode;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo}&page={page}",
                WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithTypeAndExtendedOptionAndLimit()
        {
            const int itemCount = 4;
            var type = TraktSyncItemType.Episode;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo}&limit={limit}",
                WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithExtendedInfo()
        {
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist?extended={extendedInfo}",
                                                             WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithExtendedInfoAndPage()
        {
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo}&page={page}",
                WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithExtendedInfoAndLimit()
        {
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo}&limit={limit}",
                WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithPage()
        {
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?page={page}", WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithLimit()
        {
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?limit={limit}", WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistWithPageAndLimit()
        {
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistComplete()
        {
            const int itemCount = 4;
            var type = TraktSyncItemType.Episode;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchlistExceptions()
        {
            const string uri = "sync/watchlist";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
