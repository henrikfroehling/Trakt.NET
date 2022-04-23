namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users.Lists;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_LISTS_URI = $"movies/{MOVIE_ID}/lists";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_LISTS_URI,
                                                           MOVIE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}",
                                                           MOVIE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_SortOrder_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_LISTS_URI,
                                                           MOVIE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, null, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}?page={PAGE}",
                                                           MOVIE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}?limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}",
                                                           MOVIE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}",
                                                           MOVIE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}?limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}",
                                                           MOVIE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_With_Type_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           MOVIE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Movies.GetMovieListsAsync(MOVIE_ID, LIST_TYPE, LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktMovieNotFoundException))]
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
        public async Task Test_TraktMoviesModule_GetMovieLists_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_LISTS_URI, statusCode);

            try
            {
                await client.Movies.GetMovieListsAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieLists_ArgumentsExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_LISTS_URI,
                                                           MOVIE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Movies.GetMovieListsAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieListsAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Movies.GetMovieListsAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
