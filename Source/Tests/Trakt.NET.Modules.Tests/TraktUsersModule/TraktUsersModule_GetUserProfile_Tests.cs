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
        private readonly string GET_USER_PROFILE_URI = $"users/{USERNAME}";

        [Fact]
        public async Task Test_TraktUsersModule_GetUserProfile()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, PROFILE_JSON);
            TraktResponse<ITraktUser> response = await client.Users.GetUserProfileAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUser responseValue = response.Value;

            responseValue.Username.Should().Be("sean");
            responseValue.IsPrivate.Should().BeFalse();
            responseValue.Name.Should().Be("Sean Rudford");
            responseValue.IsVIP.Should().BeTrue();
            responseValue.IsVIP_EP.Should().BeTrue();
            responseValue.JoinedAt.Should().NotHaveValue();
            responseValue.Location.Should().BeNullOrEmpty();
            responseValue.About.Should().BeNullOrEmpty();
            responseValue.Gender.Should().BeNullOrEmpty();
            responseValue.Age.Should().NotHaveValue();
            responseValue.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserProfile_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_PROFILE_URI, PROFILE_JSON);
            client.Configuration.ForceAuthorization = true;

            TraktResponse<ITraktUser> response = await client.Users.GetUserProfileAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUser responseValue = response.Value;

            responseValue.Username.Should().Be("sean");
            responseValue.IsPrivate.Should().BeFalse();
            responseValue.Name.Should().Be("Sean Rudford");
            responseValue.IsVIP.Should().BeTrue();
            responseValue.IsVIP_EP.Should().BeTrue();
            responseValue.JoinedAt.Should().NotHaveValue();
            responseValue.Location.Should().BeNullOrEmpty();
            responseValue.About.Should().BeNullOrEmpty();
            responseValue.Gender.Should().BeNullOrEmpty();
            responseValue.Age.Should().NotHaveValue();
            responseValue.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetUserProfile_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_USER_PROFILE_URI}?extended={EXTENDED_INFO}",
                PROFILE_JSON);

            TraktResponse<ITraktUser> response = await client.Users.GetUserProfileAsync(USERNAME, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUser responseValue = response.Value;

            responseValue.Username.Should().Be("sean");
            responseValue.IsPrivate.Should().BeFalse();
            responseValue.Name.Should().Be("Sean Rudford");
            responseValue.IsVIP.Should().BeTrue();
            responseValue.IsVIP_EP.Should().BeTrue();
            responseValue.JoinedAt.Should().NotHaveValue();
            responseValue.Location.Should().BeNullOrEmpty();
            responseValue.About.Should().BeNullOrEmpty();
            responseValue.Gender.Should().BeNullOrEmpty();
            responseValue.Age.Should().NotHaveValue();
            responseValue.Images.Should().BeNull();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(USERNAME);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfile_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, PROFILE_JSON);

            Func<Task<TraktResponse<ITraktUser>>> act = () => client.Users.GetUserProfileAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Users.GetUserProfileAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Users.GetUserProfileAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
