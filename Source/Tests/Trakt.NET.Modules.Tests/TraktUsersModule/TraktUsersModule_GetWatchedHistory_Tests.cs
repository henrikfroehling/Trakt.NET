﻿namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.History;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHED_HISTORY_URI = $"users/{USERNAME}/history";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_WATCHED_HISTORY_URI,
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_WATCHED_HISTORY_URI,
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktHistoryItem> response = await client.Users.GetWatchedHistoryAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                          END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                          null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                          null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                          null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, START_AT,
                                                          null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null,
                                                          END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID,
                                                          null, END_AT, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID,
                                                          null, END_AT, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Id_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?end_at={HistoryEndAt}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID,
                                                          null, END_AT, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT,
                                                          null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT,
                                                          END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_StartDate_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?start_at={HistoryStartAt}" +
                $"&end_at={HistoryEndAt}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null,
                                                          END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, END_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null,
                                                          END_AT, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null,
                                                          END_AT, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?end_at={HistoryEndAt}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null,
                                                          null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}?page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT,
                                                          null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?start_at={HistoryStartAt}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, START_AT, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null,
                                                          END_AT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&extended={EXTENDED_INFO}" +
                $"&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_EndDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?end_at={HistoryEndAt}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, END_AT,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}",
                HISTORY_JSON, 1, 10, 1, HISTORY_ITEM_COUNT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null,
                                                          null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?page={PAGE}",
                HISTORY_JSON, PAGE, 10, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?limit={HISTORY_LIMIT}",
                HISTORY_JSON, 1, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}?page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, null, null, null, null,
                                                          null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedHistory_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_HISTORY_URI}/{HISTORY_ITEM_TYPE.UriName}/{HISTORY_ITEM_ID}" +
                $"?start_at={HistoryStartAt}&end_at={HistoryEndAt}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={HISTORY_LIMIT}",
                HISTORY_JSON, PAGE, HISTORY_LIMIT, 1, HISTORY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HISTORY_LIMIT);

            TraktPagedResponse<ITraktHistoryItem> response =
                await client.Users.GetWatchedHistoryAsync(USERNAME, HISTORY_ITEM_TYPE, HISTORY_ITEM_ID,
                                                          START_AT, END_AT, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HISTORY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HISTORY_ITEM_COUNT);
            response.Limit.Should().Be(HISTORY_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktObjectNotFoundException))]
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
        public async Task Test_TraktUsersModule_GetWatchedHistory_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_HISTORY_URI, statusCode);

            try
            {
                await client.Users.GetWatchedHistoryAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
