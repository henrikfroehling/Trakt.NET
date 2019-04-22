namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string FOLLOW_USER_URI = $"users/{USERNAME}/follow";

        [Fact]
        public async Task Test_TraktUsersModule_FollowUser()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, FOLLOW_USER_RESPONSE_JSON);
            TraktResponse<ITraktUserFollowUserPostResponse> response = await client.Users.FollowUserAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserFollowUserPostResponse responseValue = response.Value;

            responseValue.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());
            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("sean");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Sean Rudford");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_FollowUser_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(FOLLOW_USER_URI, FOLLOW_USER_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktUserFollowUserPostResponse>>> act = () => client.Users.FollowUserAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.FollowUserAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.FollowUserAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
