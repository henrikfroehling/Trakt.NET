namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHED_MOVIES_URI = $"users/{USERNAME}/watched/movies";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);
            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchedMovies_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHED_MOVIES_URI}?extended={EXTENDED_INFO}",
                WATCHED_MOVIES_JSON);

            TraktListResponse<ITraktWatchedMovie> response = await client.Users.GetWatchedMoviesAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetWatchedMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);

            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Users.GetWatchedMoviesAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetWatchedMoviesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetWatchedMoviesAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
