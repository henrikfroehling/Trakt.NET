namespace TraktNet.Modules.Tests.TraktListsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Lists")]
    public partial class TraktListsModule_Tests
    {
        private readonly string GET_LIST_ITEMS_URI = $"lists/{LIST_ID}/items";

        [Fact]
        public async Task Test_TraktListsModule_GetListItems()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_ITEMS_URI,
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response = await client.Lists.GetListItemsAsync(LIST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}?extended={EXTENDED_INFO}",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}?page={PAGE}",
                LIST_ITEMS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}?limit={LIMIT}",
                LIST_ITEMS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}?page={PAGE}&limit={LIMIT}",
                LIST_ITEMS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_Type_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}" +
                $"?page={PAGE}&limit={LIMIT}", LIST_ITEMS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_With_ExtendedInfo_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                LIST_ITEMS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                LIST_ITEMS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktListNotFoundException))]
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
        public async Task Test_TraktListsModule_GetListItems_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_ITEMS_URI, statusCode);

            try
            {
                await client.Lists.GetListItemsAsync(LIST_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
