namespace TraktApiSharp.Tests.Modules.TraktUsersModule
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

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public void Test_TraktUsersModule_GetWatchlist()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist", WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithOAuthEnforced()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"users/{username}/watchlist", WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithType()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var type = TraktSyncItemType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}",
                WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithTypeAndExtendedOption()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedInfo}",
                WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedInfo).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithTypeAndExtendedOptionAndPage()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedInfo}&page={page}",
                WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithTypeAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}?extended={extendedInfo}&limit={limit}",
                WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithExtendedInfo()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedInfo}",
                WATCHLIST_JSON, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedInfo).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithExtendedInfoAndPage()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedInfo}&page={page}",
                WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithExtendedInfoAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedInfo}&limit={limit}",
                WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithExtendedInfoAndPageAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithPage()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?page={page}",
                WATCHLIST_JSON, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?limit={limit}",
                WATCHLIST_JSON, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistWithPageAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist?page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, null, null, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistComplete()
        {
            const string username = "sean";
            const int itemCount = 4;
            const string sortBy = "rank";
            const string sortHow = "asc";
            var type = TraktSyncItemType.Movie;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/watchlist/{type.UriName}" +
                $"?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHLIST_JSON, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username, type, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktUsersModule_GetWatchlistExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}/watchlist";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(username);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchlistArgumentExceptions()
        {
            Func<Task<TraktPagedResponse<ITraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchlistAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
