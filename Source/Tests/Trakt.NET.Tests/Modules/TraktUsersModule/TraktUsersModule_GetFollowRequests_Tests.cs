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
        private const string GET_FOLLOW_REQUESTS_URI = "users/requests";

        [Fact]
        public async Task Test_TraktUsersModule_GetFollowRequests()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, FOLLOW_REQUESTS_JSON);
            TraktListResponse<ITraktUserFollowRequest> response = await client.Users.GetFollowRequestsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetFollowRequests_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_FOLLOW_REQUESTS_URI}?extended={EXTENDED_INFO}",
                FOLLOW_REQUESTS_JSON);

            TraktListResponse<ITraktUserFollowRequest> response = await client.Users.GetFollowRequestsAsync(EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetFollowRequests_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_FOLLOW_REQUESTS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktUserFollowRequest>>> act = () => client.Users.GetFollowRequestsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
