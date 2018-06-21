namespace TraktNet.Tests.Modules.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.History;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_WATCHED_HISTORY_URI = "sync/history";

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchedHistory()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_WATCHED_HISTORY_URI,
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync();

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={START_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                         END_AT, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                         null, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                         null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                         null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                         null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null,
                                                         END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null,
                                                         END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null,
                                                         END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, null, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT,
                                                         END_AT, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null,
                                                         END_AT, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?end_at={END_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, END_AT,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null,
                                                         null, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, null, null, null,
                                                         null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, END_AT, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={START_AT.ToTraktLongDateTimeString()}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, START_AT, null, null,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, END_AT, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}",
                WATCHED_HISTORY_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, EXTENDED_INFO);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, EXTENDED_INFO,
                                                         pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?page={PAGE}",
                WATCHED_HISTORY_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?limit={LIMIT}",
                WATCHED_HISTORY_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}?page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(null, null, null, null, null, pagedParameters);

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
        public async Task Test_TraktSyncModule_GetWatchedHistory_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={START_AT.ToTraktLongDateTimeString()}&end_at={END_AT.ToTraktLongDateTimeString()}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                WATCHED_HISTORY_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Sync.GetWatchedHistoryAsync(HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT,
                                                         EXTENDED_INFO, pagedParameters);

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
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedHistory_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_HISTORY_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktHistoryItem>>> act = () => client.Sync.GetWatchedHistoryAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
