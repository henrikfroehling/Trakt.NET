namespace TraktNet.Modules.Tests.TraktUsersModule
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

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_FOLLOWING_URI = $"users/{USERNAME}/following";

        [Fact]
        public async Task Test_TraktUsersModule_GetFollowing()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, FOLLOWERS_JSON);
            TraktListResponse<ITraktUserFollower> response = await client.Users.GetFollowingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetFollowing_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOWING_URI, FOLLOWERS_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktListResponse<ITraktUserFollower> response = await client.Users.GetFollowingAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetFollowing_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_FOLLOWING_URI}?extended={EXTENDED_INFO}",
                FOLLOWERS_JSON);

            TraktListResponse<ITraktUserFollower> response = await client.Users.GetFollowingAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowing_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_FOLLOWING_URI, FOLLOWERS_JSON);

            Func<Task<TraktListResponse<ITraktUserFollower>>> act = () => client.Users.GetFollowingAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetFollowingAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetFollowingAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
