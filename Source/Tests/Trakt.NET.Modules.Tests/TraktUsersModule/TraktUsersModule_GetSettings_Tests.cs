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

    [TestCategory("Modules.Users")]
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
            responseValue.Connections.Twitter.Should().BeTrue();
            responseValue.Connections.Google.Should().BeTrue();
            responseValue.Connections.Tumblr.Should().BeFalse();
            responseValue.Connections.Medium.Should().BeFalse();
            responseValue.Connections.Slack.Should().BeFalse();
            responseValue.SharingText.Should().NotBeNull();
            responseValue.SharingText.Watching.Should().Be("I'm watching [item]");
            responseValue.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_GetSettings_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SETTINGS_URI, statusCode);

            try
            {
                await client.Users.GetSettingsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
