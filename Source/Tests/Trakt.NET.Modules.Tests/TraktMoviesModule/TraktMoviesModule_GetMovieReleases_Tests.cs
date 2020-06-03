namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_RELEASES_URI = $"movies/{MOVIE_ID}/releases";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, MOVIE_RELEASES_JSON);
            TraktListResponse<ITraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RELEASES_URI, MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieReleases_Single()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_RELEASES_URI}/{COUNTRY_CODE}", MOVIE_RELEASES_JSON);
            TraktListResponse<ITraktMovieRelease> response = await client.Movies.GetMovieReleasesAsync(MOVIE_ID, COUNTRY_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieReleases_Single_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_RELEASES_URI}/{COUNTRY_CODE}", MOVIE_RELEASES_JSON);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act = () => client.Movies.GetMovieReleasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync("movie id");
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID, "usa");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Movies.GetMovieReleasesAsync(MOVIE_ID, "u");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
