namespace TraktApiSharp.Tests.Modules.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        [Fact]
        public void Test_TraktUsersModule_GetUserProfile()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}", PROFILE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetUserProfileWithExtendedInfo()
        {
            const string username = "sean";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"users/{username}?extended={extendedInfo}", PROFILE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetUserProfileWithOAuthEnforced()
        {
            const string username = "sean";

            TestUtility.SetupMockResponseWithOAuth($"users/{username}", PROFILE_JSON);
            TestUtility.MOCK_TEST_CLIENT.Configuration.ForceAuthorization = true;

            var response = TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktUsersModule_GetUserProfileExceptions()
        {
            const string username = "sean";
            var uri = $"users/{username}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(username);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetUserProfileArgumentExceptions()
        {
            Func<Task<TraktResponse<ITraktUser>>> act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Users.GetUserProfileAsync("user name");
            act.Should().Throw<ArgumentException>();
        }
    }
}
