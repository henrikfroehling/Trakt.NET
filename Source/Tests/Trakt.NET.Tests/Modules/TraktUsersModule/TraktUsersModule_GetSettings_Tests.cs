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
        private const string GET_SETTINGS_URI = "users/settings";

        [Fact]
        public async Task Test_TraktUsersModule_GetSettings()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, SETTINGS_JSON);
            TraktResponse<ITraktUserSettings> response = await client.Users.GetSettingsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktUserSettings responseValue = response.Value;

            responseValue.User.Should().NotBeNull();
            responseValue.User.Username.Should().Be("justin");
            responseValue.User.IsPrivate.Should().BeFalse();
            responseValue.User.Name.Should().Be("Justin Nemeth");
            responseValue.User.IsVIP.Should().BeTrue();
            responseValue.User.IsVIP_EP.Should().BeFalse();
            responseValue.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            responseValue.User.Location.Should().Be("San Diego, CA");
            responseValue.User.About.Should().Be("Co-founder of trakt.");
            responseValue.User.Gender.Should().Be("male");
            responseValue.User.Age.Should().Be(32);
            responseValue.User.Images.Should().NotBeNull();
            responseValue.User.Images.Avatar.Should().NotBeNull();
            responseValue.User.Images.Avatar.Full.Should().Be("https://secure.gravatar.com/avatar/30c2f0dfbc39e48656f40498aa871e33?r=pg&s=256");
            responseValue.Account.Should().NotBeNull();
            responseValue.Account.TimeZoneId.Should().Be("America/Los_Angeles");
            responseValue.Account.Time24Hr.Should().BeFalse();
            responseValue.Account.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            responseValue.Connections.Should().NotBeNull();
            responseValue.Connections.Facebook.Should().BeTrue();
            responseValue.Connections.Twitter.Should().BeTrue();
            responseValue.Connections.Google.Should().BeTrue();
            responseValue.Connections.Tumblr.Should().BeFalse();
            responseValue.Connections.Medium.Should().BeFalse();
            responseValue.Connections.Slack.Should().BeFalse();
            responseValue.SharingText.Should().NotBeNull();
            responseValue.SharingText.Watching.Should().Be("I'm watching [item]");
            responseValue.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktUsersModule_GetSettings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktUserSettings>>> act = () => client.Users.GetSettingsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
