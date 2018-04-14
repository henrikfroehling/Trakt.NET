namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMovieLists()
        {
            const string movieId = "94024";
            const int itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists", MOVIE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithType()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}",
                                                                MOVIE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithSortOrderAndWithoutType()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists",
                                                                MOVIE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithPage()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?page={page}",
                                                                MOVIE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithLimit()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?limit={limit}",
                                                                MOVIE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithPageAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?page={page}&limit={limit}",
                                                                MOVIE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndSortOrder()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}",
                                                                MOVIE_LISTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndPage()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?page={page}",
                                                                MOVIE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?limit={limit}",
                                                                MOVIE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndPageAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?page={page}&limit={limit}",
                                                                MOVIE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndSortOrderAndPage()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                                                                MOVIE_LISTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsWithTypeAndSortOrderAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                MOVIE_LISTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsComplete()
        {
            const string movieId = "94024";
            const int itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}" +
                                                                $"?page={page}&limit={limit}",
                                                                MOVIE_LISTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId);
            act.Should().Throw<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieListsArgumentsExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists", MOVIE_LISTS_JSON);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
