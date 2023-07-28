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
    using TraktNet.Parameters;
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
        public async Task Test_TraktListsModule_GetListItems_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/items",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response = await client.Lists.GetListItemsAsync(TRAKT_LIST_ID);

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
        public async Task Test_TraktListsModule_GetListItems_With_ListIds_TraktID()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/items",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response = await client.Lists.GetListItemsAsync(listIds);

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
        public async Task Test_TraktListsModule_GetListItems_With_ListIds_Slug()
        {
            var listIds = new TraktListIds
            {
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{LIST_SLUG}/items",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response = await client.Lists.GetListItemsAsync(listIds);

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
        public async Task Test_TraktListsModule_GetListItems_With_ListIds()
        {
            var listIds = new TraktListIds
            {
                Trakt = TRAKT_LIST_ID,
                Slug = LIST_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"lists/{TRAKT_LIST_ID}/items",
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktListItem> response = await client.Lists.GetListItemsAsync(listIds);

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

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                LIST_ITEMS_JSON, 2, LIMIT, 5, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                LIST_ITEMS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                LIST_ITEMS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                LIST_ITEMS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                LIST_ITEMS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                LIST_ITEMS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                LIST_ITEMS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktListItem> response =
                await client.Lists.GetListItemsAsync(LIST_ID, LIST_ITEM_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_LIST_ITEMS_URI}/{LIST_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                LIST_ITEMS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
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

        [Fact]
        public async Task Test_TraktListsModule_GetListItems_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_LIST_ITEMS_URI,
                LIST_ITEMS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktListItem>>> act = () => client.Lists.GetListItemsAsync(default(ITraktListIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Lists.GetListItemsAsync(new TraktListIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Lists.GetListItemsAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
