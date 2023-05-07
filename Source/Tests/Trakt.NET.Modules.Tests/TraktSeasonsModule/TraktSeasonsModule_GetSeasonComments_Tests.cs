namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_COMMENTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/comments";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, SEASON_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                                                           SEASON_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?page={PAGE}",
                                                           SEASON_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                                                           SEASON_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 2, LIMIT, 5, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 2, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 1, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 2, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 1, LIMIT, 2, ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 1, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_COMMENTS_JSON, 2, LIMIT, 2, ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
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
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
