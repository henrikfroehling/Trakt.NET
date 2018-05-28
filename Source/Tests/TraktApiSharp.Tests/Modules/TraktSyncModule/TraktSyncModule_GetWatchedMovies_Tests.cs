namespace TraktApiSharp.Tests.Modules.TraktSyncModule
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

    [Category("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_WATCHED_MOVIES_URI = "sync/watched/movies";

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchedMovies()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, WATCHED_MOVIES_JSON);
            TraktListResponse<ITraktWatchedMovie> response = await client.Sync.GetWatchedMoviesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetWatchedMovies_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_WATCHED_MOVIES_URI}?extended={EXTENDED_INFO}",
                WATCHED_MOVIES_JSON);

            TraktListResponse<ITraktWatchedMovie> response = await client.Sync.GetWatchedMoviesAsync(EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSyncModule_GetWatchedMovies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_WATCHED_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktWatchedMovie>>> act = () => client.Sync.GetWatchedMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
