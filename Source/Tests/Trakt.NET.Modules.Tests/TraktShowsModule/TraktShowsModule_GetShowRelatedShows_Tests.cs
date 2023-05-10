namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_RELATED_SHOWS_URI = $"shows/{SHOW_ID}/related";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_RELATED_SHOWS_URI,
                SHOW_RELATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}",
                SHOW_RELATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?page={PAGE}",
                SHOW_RELATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                SHOW_RELATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?page={PAGE}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, PAGE, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, PAGE, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=2&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 2, RELATED_SHOWS_LIMIT, 5, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=2&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 2, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=1&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=1&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=2&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 2, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=1&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=1&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page=2&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 2, RELATED_SHOWS_LIMIT, 2, ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, statusCode);

            try
            {
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
