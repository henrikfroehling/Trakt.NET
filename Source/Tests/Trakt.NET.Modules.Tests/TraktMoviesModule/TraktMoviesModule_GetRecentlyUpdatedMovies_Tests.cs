namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private const string GET_RECENTLY_UPDATED_MOVIES_URI = "movies/updates";

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_MOVIES_URI,
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync();

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?extended={EXTENDED_INFO}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, EXTENDED_INFO);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?page={PAGE}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?page={PAGE}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_With_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                                                           RECENTLY_UPDATED_MOVIES_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 2, LIMIT, 5, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 2, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 2, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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

            TestUtility.ResetMockClient(client,
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 2, ITEM_COUNT);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 1, LIMIT, 2, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktRecentlyUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(TODAY, EXTENDED_INFO, pagedParameters);

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

            TestUtility.ResetMockClient(client,
                $"{GET_RECENTLY_UPDATED_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIES_JSON, 2, LIMIT, 2, ITEM_COUNT);

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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovies_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_MOVIES_URI, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
