namespace TraktNet.Tests.Modules.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_WATCHING_USERS_URI = $"movies/{MOVIE_ID}/watching";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_WATCHING_USERS_URI}?extended={EXTENDED_INFO}", MOVIE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktMovieNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(MOVIE_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktMoviesModule_GetMovieWatchingUsers_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_WATCHING_USERS_URI, MOVIE_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Movies.GetMovieWatchingUsersAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieWatchingUsersAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Movies.GetMovieWatchingUsersAsync("movie id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
