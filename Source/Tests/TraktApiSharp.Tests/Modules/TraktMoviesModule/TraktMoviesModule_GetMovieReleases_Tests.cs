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
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases", MOVIE_RELEASES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleasesExceptions()
        {
            const string movieId = "94024";
            var uri = $"movies/{movieId}/releases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId);
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
        public void Test_TraktMoviesModule_GetMovieReleasesArgumentExceptions()
        {
            const string movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases", MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieSingleRelease()
        {
            const string movieId = "94024";
            const string countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", MOVIE_RELEASES_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, countryCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieSingleReleaseExceptions()
        {
            const string movieId = "94024";
            const string countryCode = "us";
            var uri = $"movies/{movieId}/releases/{countryCode}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, countryCode);
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
        public void Test_TraktMoviesModule_GetMovieSingleReleaseArgumentExceptions()
        {
            const string movieId = "94024";
            const string countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync("movie id");
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, "usa");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, "u");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
