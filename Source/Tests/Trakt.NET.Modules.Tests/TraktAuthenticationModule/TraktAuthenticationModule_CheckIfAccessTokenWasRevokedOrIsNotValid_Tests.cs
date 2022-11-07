namespace TraktNet.Modules.Tests.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        // "Fake-Request" is sync/last_activities
        private const string CHECK_ACCESS_TOKEN_URI = "sync/last_activities";

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Success()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, SYNC_LAST_ACTIVITIES_JSON);
            bool response = await client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            response.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Failed()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Unauthorized);
            bool response = await client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            response.Should().BeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
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
        public async Task Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, statusCode);

            try
            {
                await client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync("access token");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
