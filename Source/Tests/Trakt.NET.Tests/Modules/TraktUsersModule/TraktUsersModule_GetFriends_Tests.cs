namespace TraktNet.Tests.Modules.TraktUsersModule
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

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_FRIENDS_URI = $"users/{USERNAME}/friends";

        [Fact]
        public async Task Test_TraktUsersModule_GetFriends()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, FRIENDS_JSON);
            TraktListResponse<ITraktUserFriend> response = await client.Users.GetFriendsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetFriends_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FRIENDS_URI, FRIENDS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktUserFriend> response = await client.Users.GetFriendsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetFriends_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_FRIENDS_URI}?extended={EXTENDED_INFO}",
                FRIENDS_JSON);

            TraktListResponse<ITraktUserFriend> response =
                await client.Users.GetFriendsAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFriends_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FRIENDS_URI, FRIENDS_JSON);

            Func<Task<TraktListResponse<ITraktUserFriend>>> act = () => client.Users.GetFriendsAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetFriendsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetFriendsAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
