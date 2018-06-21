namespace TraktNet.Tests.Modules.TraktShowsModule
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

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_WATCHING_USERS_URI = $"shows/{SHOW_ID}/watching";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_WATCHING_USERS_URI,
                SHOW_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response =
                await client.Shows.GetShowWatchingUsersAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowWatchingUsers_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_WATCHING_USERS_URI}?extended={EXTENDED_INFO}",
                SHOW_WATCHING_USERS_JSON);

            TraktListResponse<ITraktUser> response =
                await client.Shows.GetShowWatchingUsersAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_WATCHING_USERS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowWatchingUsers_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_WATCHING_USERS_URI,
                SHOW_WATCHING_USERS_JSON);

            Func<Task<TraktListResponse<ITraktUser>>> act = () => client.Shows.GetShowWatchingUsersAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowWatchingUsersAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowWatchingUsersAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
