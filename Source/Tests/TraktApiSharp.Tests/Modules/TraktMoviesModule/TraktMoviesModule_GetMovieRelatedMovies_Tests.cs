namespace TraktApiSharp.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMovieRelatedMovies()
        {
            const string movieId = "94024";
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", MOVIE_RELATED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithExtendedInfo()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo}",
                                                                MOVIE_RELATED_MOVIES_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithPage()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}",
                                                                MOVIE_RELATED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithExtendedInfoAndPage()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo}&page={page}",
                                                                MOVIE_RELATED_MOVIES_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?limit={limit}",
                                                                MOVIE_RELATED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithExtendedInfoAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo}&limit={limit}",
                                                                MOVIE_RELATED_MOVIES_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesWithPageAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}&limit={limit}",
                                                                MOVIE_RELATED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesComplete()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo}&page={page}&limit={limit}",
                                                                MOVIE_RELATED_MOVIES_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}/related";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId);
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
        public void Test_TraktMoviesModule_GetMovieRelatedMoviesArgumentExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", MOVIE_RELATED_MOVIES_JSON);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
