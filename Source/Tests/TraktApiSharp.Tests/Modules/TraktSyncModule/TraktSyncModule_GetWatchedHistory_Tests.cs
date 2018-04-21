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
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory()
        {
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history", WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync().Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithType()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}",
                                                             WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndId()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}/{itemId}",
                                                             WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDate()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDate()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}" +
                                                             $"&extended={extendedInfo}&page={page}&limit={limit}",
                                                             WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDate()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}",
                                                             WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndPage()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}" +
                                                             $"&page={page}&limit={limit}",
                                                             WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndExtendedOption()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo}",
                                                             WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndExtendedOptionAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo}&page={page}",
                                                             WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndExtendedOptionAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo}&limit={limit}",
                                                             WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndExtendedOptionAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndPage()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?page={page}",
                                                             WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?limit={limit}",
                                                             WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithTypeAndPageAndLimit()
        {
            var type = TraktSyncItemType.Movie;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?page={page}&limit={limit}",
                                                             WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndExtendedOption()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndPage()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndExtendedOptionAndPageAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDate()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOption()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDate()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndPage()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithStartDateAndPageAndLimit()
        {
            var startAt = DateTime.UtcNow.AddMonths(-1);
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndExtendedOption()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndPage()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndLimit()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndExtendedOptionAndPageAndLimit()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDate()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndPage()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndLimit()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithEndDateAndPageAndLimit()
        {
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithExtendedInfo()
        {
            const int itemCount = 4;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo}",
                WATCHED_HISTORY_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithExtendedInfoAndPage()
        {
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo}&page={page}",
                WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithExtendedInfoAndLimit()
        {
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo}&limit={limit}",
                WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
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
        public void Test_TraktSyncModule_GetWatchedHistoryWithPage()
        {
            const int itemCount = 4;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}",
                                                             WATCHED_HISTORY_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithLimit()
        {
            const int itemCount = 4;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?limit={limit}",
                                                             WATCHED_HISTORY_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryWithPageAndLimit()
        {
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}&limit={limit}",
                                                             WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters).Result;

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
        public void Test_TraktSyncModule_GetWatchedHistoryComplete()
        {
            var type = TraktSyncItemType.Movie;
            const uint itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            const int itemCount = 4;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo}&page={page}&limit={limit}",
                WATCHED_HISTORY_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
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
        public void Test_TraktSyncModule_GetWatchedHistoryExceptions()
        {
            const string uri = "sync/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync();
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
