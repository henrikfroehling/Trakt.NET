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
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMovieComments()
        {
            const string movieId = "94024";
            const int itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments",
                                                                MOVIE_COMMENTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithSortOrder()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}",
                                                                MOVIE_COMMENTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithPage()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}",
                                                                MOVIE_COMMENTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithSortOrderAndPage()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}",
                                                                MOVIE_COMMENTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?limit={limit}",
                                                                MOVIE_COMMENTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithSortOrderAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?limit={limit}",
                                                                MOVIE_COMMENTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsWithPageAndLimit()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}&limit={limit}",
                                                                MOVIE_COMMENTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsComplete()
        {
            const string movieId = "94024";
            const int itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                MOVIE_COMMENTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

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
        public void Test_TraktMoviesModule_GetMovieCommentsExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId);
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
        public void Test_TraktMoviesModule_GetMovieCommentsArgumentExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments", MOVIE_COMMENTS_JSON);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
