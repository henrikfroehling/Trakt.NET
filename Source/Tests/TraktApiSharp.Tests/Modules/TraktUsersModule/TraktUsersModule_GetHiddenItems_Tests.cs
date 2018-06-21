namespace TraktNet.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GetHiddenItemsUri,
                HIDDEN_ITEMS_JSON, 1, 10, 1, HIDDEN_ITEMS_COUNT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}",
                HIDDEN_ITEMS_JSON, 1, 10, 1, HIDDEN_ITEMS_COUNT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}&extended={EXTENDED_INFO}",
                HIDDEN_ITEMS_JSON, 1, 10, 1, HIDDEN_ITEMS_COUNT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}&page={PAGE}",
                HIDDEN_ITEMS_JSON, PAGE, 10, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, 1, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}&page={PAGE}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, PAGE, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?extended={EXTENDED_INFO}",
                HIDDEN_ITEMS_JSON, 1, 10, 1, HIDDEN_ITEMS_COUNT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?extended={EXTENDED_INFO}&page={PAGE}",
                HIDDEN_ITEMS_JSON, PAGE, 10, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?extended={EXTENDED_INFO}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, 1, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?extended={EXTENDED_INFO}&page={PAGE}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, PAGE, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?page={PAGE}",
                HIDDEN_ITEMS_JSON, PAGE, 10, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, 1, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?page={PAGE}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, PAGE, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetHiddenItems_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GetHiddenItemsUri}?type={HIDDEN_ITEM_TYPE.UriName}" +
                $"&extended={EXTENDED_INFO}&page={PAGE}&limit={HIDDEN_ITEMS_LIMIT}",
                HIDDEN_ITEMS_JSON, PAGE, HIDDEN_ITEMS_LIMIT, 1, HIDDEN_ITEMS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, HIDDEN_ITEMS_LIMIT);

            TraktPagedResponse<ITraktUserHiddenItem> response =
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION, HIDDEN_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(HIDDEN_ITEMS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(HIDDEN_ITEMS_COUNT);
            response.Limit.Should().Be(HIDDEN_ITEMS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetHiddenItems_With_Type_And_Page_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GetHiddenItemsUri,
                HIDDEN_ITEMS_JSON, 1, 10, 1, HIDDEN_ITEMS_COUNT);

            Func<Task<TraktPagedResponse<ITraktUserHiddenItem>>> act = () => client.Users.GetHiddenItemsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetHiddenItemsAsync(TraktHiddenItemsSection.Unspecified);
            act.Should().Throw<ArgumentException>();
        }
    }
}
