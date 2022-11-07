namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
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
        public async Task Test_TraktUsersModule_GetHiddenItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GetHiddenItemsUri, statusCode);

            try
            {
                await client.Users.GetHiddenItemsAsync(HIDDEN_ITEMS_SECTION);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
