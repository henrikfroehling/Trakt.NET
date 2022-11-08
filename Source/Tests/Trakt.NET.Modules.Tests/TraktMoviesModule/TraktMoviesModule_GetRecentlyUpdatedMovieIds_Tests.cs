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
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private const string GET_RECENTLY_UPDATED_MOVIE_IDS_URI = "movies/updates/id";

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_MOVIE_IDS_URI,
                RECENTLY_UPDATED_MOVIE_IDS_JSON, 1, 10, 1, UPDATED_IDS_COUNT);

            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}/{TODAY.ToTraktDateString()}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, 1, 10, 1, UPDATED_IDS_COUNT);

            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(TODAY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}?page={PAGE}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, PAGE, 10, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}?limit={LIMIT}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, 1, LIMIT, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}?page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, PAGE, LIMIT, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}/{TODAY.ToTraktDateString()}?page={PAGE}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, PAGE, 10, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(TODAY, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}/{TODAY.ToTraktDateString()}?limit={LIMIT}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, 1, LIMIT, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(TODAY, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_MOVIE_IDS_URI}/{TODAY.ToTraktDateString()}?page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_MOVIE_IDS_JSON, PAGE, LIMIT, 1, UPDATED_IDS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<int> response = await client.Movies.GetRecentlyUpdatedMovieIdsAsync(TODAY, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(UPDATED_IDS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(UPDATED_IDS_COUNT);
            response.Limit.Should().Be(LIMIT);
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
        public async Task Test_TraktMoviesModule_GetRecentlyUpdatedMovieIds_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_MOVIE_IDS_URI, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMovieIdsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
