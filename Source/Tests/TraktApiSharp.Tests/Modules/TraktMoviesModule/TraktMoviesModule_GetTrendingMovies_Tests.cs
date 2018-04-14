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
        public void Test_TraktMoviesModule_GetTrendingMovies()
        {
            const int itemCount = 2;
            const int userCount = 300;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending", TRENDING_MOVIES_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter}",
                                                                TRENDING_MOVIES_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfo()
        {
            const int itemCount = 2;
            const int userCount = 300;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo}",
                                                                TRENDING_MOVIES_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfoFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo}&{filter}",
                                                                TRENDING_MOVIES_JSON, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithPage()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}", TRENDING_MOVIES_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithPageFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter}&page={page}",
                                                                TRENDING_MOVIES_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfoAndPage()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo}&page={page}",
                                                                TRENDING_MOVIES_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfoAndPageFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo}&page={page}&{filter}",
                TRENDING_MOVIES_JSON, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?limit={limit}", TRENDING_MOVIES_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter}&limit={limit}",
                                                                TRENDING_MOVIES_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfoAndLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo}&limit={limit}",
                                                                TRENDING_MOVIES_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithExtendedInfoAndLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo}&limit={limit}&{filter}",
                TRENDING_MOVIES_JSON, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithPageAndLimit()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}",
                                                                TRENDING_MOVIES_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesWithPageAndLimitFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}&{filter}",
                                                                TRENDING_MOVIES_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesComplete()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo}&page={page}&limit={limit}",
                                                                TRENDING_MOVIES_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesCompleteFiltered()
        {
            const int itemCount = 2;
            const int userCount = 300;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo}&page={page}&limit={limit}&{filter}",
                TRENDING_MOVIES_JSON, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetTrendingMoviesExceptions()
        {
            const string uri = "movies/trending";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktTrendingMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync();
            act.Should().Throw<TraktNotFoundException>();

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
    }
}
