namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users.Notes;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_USER_NOTES_URI = $"users/{USERNAME}/notes";

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_NOTES_URI,
                NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserNoteItem> response = await client.Users.GetUserNotesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NOTES_URI, NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);
            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktUserNoteItem> response = await client.Users.GetUserNotesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_OAuth_Enforced_For_Username_Me()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"users/me/notes", NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);
            TraktPagedResponse<ITraktUserNoteItem> response = await client.Users.GetUserNotesAsync("me");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}",
                NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserNoteItem> response = await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}",
                NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}?page={PAGE}",
                NOTES_ITEMS_JSON, PAGE, 10, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}?limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}?page={PAGE}&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, PAGE, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?extended={EXTENDED_INFO}",
                NOTES_ITEMS_JSON, 1, 10, 1, NOTES_ITEM_COUNT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                NOTES_ITEMS_JSON, PAGE, 10, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?extended={EXTENDED_INFO}&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_USER_NOTES_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, PAGE, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?page={PAGE}",
                NOTES_ITEMS_JSON, PAGE, 10, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}?page={PAGE}&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, PAGE, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, PAGE, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 2, NOTES_ITEM_LIMIT, 5, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 2, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 1, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 2, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserNotes_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 1, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, NOTES_ITEM_LIMIT);

            TraktPagedResponse<ITraktUserNoteItem> response =
                await client.Users.GetUserNotesAsync(USERNAME, NOTES_OBJECT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_USER_NOTES_URI}/{NOTES_OBJECT_TYPE.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={NOTES_ITEM_LIMIT}",
                NOTES_ITEMS_JSON, 2, NOTES_ITEM_LIMIT, 2, NOTES_ITEM_COUNT);

            response = await response.GetNextPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(NOTES_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(NOTES_ITEM_COUNT);
            response.Limit.Should().Be(NOTES_ITEM_LIMIT);
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
        [InlineData((HttpStatusCode)420, typeof(TraktUserAccountLimitException))]
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktFailedVIPValidationException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_GetUserNotes_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_NOTES_URI, statusCode);

            try
            {
                await client.Users.GetUserNotesAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
