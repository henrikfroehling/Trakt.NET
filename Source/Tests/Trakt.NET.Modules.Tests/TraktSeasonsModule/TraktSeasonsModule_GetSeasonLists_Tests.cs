namespace TraktNet.Modules.Tests.TraktSeasonsModule
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

    [TestCategory("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_LISTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/lists";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI, SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI,
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktSeasonNotFoundException))]
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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
