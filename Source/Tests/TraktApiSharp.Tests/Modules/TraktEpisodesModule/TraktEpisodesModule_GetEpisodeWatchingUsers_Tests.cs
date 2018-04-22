namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_WATCHING_USERS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/watching";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, EPISODE_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_WATCHING_USERS_URI}?extended={EXTENDED_INFO}",
                                                           EPISODE_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response = await client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsers_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWatchingUsersArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_WATCHING_USERS_URI, EPISODE_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Episodes.GetEpisodeWatchingUsersAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeWatchingUsersAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
