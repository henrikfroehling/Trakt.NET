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
        private readonly string APPROVE_FOLLOW_REQUEST_URI = $"users/requests/{REQUEST_ID}";

        [Fact]
        public async Task Test_TraktUsersModule_ApproveFollowRequest()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, FOLLOWER_JSON);
            TraktResponse<ITraktUserFollower> response = await client.Users.ApproveFollowRequestAsync(REQUEST_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserFollower responseValue = response.Value;

            responseValue.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktObjectNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(REQUEST_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_ApproveFollowRequest_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(APPROVE_FOLLOW_REQUEST_URI, FOLLOWER_JSON);

            Func<Task<TraktResponse<ITraktUserFollower>>> act = () => client.Users.ApproveFollowRequestAsync(0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
