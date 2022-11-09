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
        public async Task Test_TraktUsersModule_GetUserProfile_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_USER_PROFILE_URI, statusCode);

            try
            {
                await client.Users.GetUserProfileAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
