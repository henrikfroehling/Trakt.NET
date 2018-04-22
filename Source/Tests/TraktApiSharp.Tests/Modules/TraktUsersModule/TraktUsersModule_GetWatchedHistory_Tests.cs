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
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistory()
        {
            const string username = "sean";
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history", HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithOAuthEnforced()
        {
            const string username = "sean";
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"users/{username}/history", HISTORY_JSON, 1, 10, 1, itemCount);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithType()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}",
                                                                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndId()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}/{itemId}",
                                                                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDate()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Season;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOption()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOption()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOption()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            const string username = "sean";
            const uint itemId = 4U;
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOption()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDate()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}",
                                                                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                                                                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                                                                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                                                                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, null,
                                                                                     null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOption()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Episode;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOption()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDate()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}",
                                                                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndPage()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                                                                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                                                                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                                                                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndExtendedOption()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}?extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}" +
                                                                $"?extended={extendedInfo}&page={page}&limit={limit}",
                                                                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndPage()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?page={page}",
                                                                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndLimit()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?limit={limit}",
                                                                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithTypeAndPageAndLimit()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Show;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"users/{username}/history/{type.UriName}?page={page}&limit={limit}",
                                                                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndExtendedOption()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDate()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOption()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDate()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndPage()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithStartDateAndPageAndLimit()
        {
            const string username = "sean";
            var startAt = DateTime.Now.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, startAt, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndExtendedOption()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndPage()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndPageAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDate()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndPage()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithEndDateAndPageAndLimit()
        {
            const string username = "sean";
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, endAt, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithExtendedInfo()
        {
            const string username = "sean";
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedInfo}",
                HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithExtendedInfoAndPage()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedInfo}&page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithExtendedInfoAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedInfo}&limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithExtendedInfoAndPageAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history?extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithPage()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?page={page}",
                HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?limit={limit}",
                HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryWithPageAndLimit()
        {
            const string username = "sean";
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history" +
                $"?page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, null, null, null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryComplete()
        {
            const string username = "sean";
            var type = TraktSyncItemType.Movie;
            const uint itemId = 4U;
            var startAt = DateTime.Now.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"users/{username}/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username, type, itemId, startAt, endAt,
                                                                                     extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedHistoryExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(username);
            act.Should().Throw<TraktObjectNotFoundException>();

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
        public void Test_TraktUsersModule_GetWatchedHistoryArgumentExceptions()
        {
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetWatchedHistoryAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
