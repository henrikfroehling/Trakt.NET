namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_WATCHING_USERS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/watching";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, SEASON_WATCHING_USERS_JSON);
            TraktListResponse<ITraktUser> response = await client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_WATCHING_USERS_URI}?extended={EXTENDED_INFO}",
                                                           SEASON_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response = await client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktSeasonNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonWatchingUsers_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_WATCHING_USERS_URI, SEASON_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Seasons.GetSeasonWatchingUsersAsync(null, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonWatchingUsersAsync(string.Empty, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonWatchingUsersAsync("show id", SEASON_NR);
            act.Should().Throw<ArgumentException>();
        }
    }
}
