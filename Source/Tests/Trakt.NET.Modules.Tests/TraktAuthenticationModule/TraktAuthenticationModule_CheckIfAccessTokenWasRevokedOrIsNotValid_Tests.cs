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

    [Category("Modules.Authentication")]
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

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.NotFound);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadRequest);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Forbidden);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Conflict);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.InternalServerError);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadGateway);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)412);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)422);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)429);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)503);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)504);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)520);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)521);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)522);
            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAccessTokenWasRevokedOrIsNotValid_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<bool>> act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.CheckIfAccessTokenWasRevokedOrIsNotValidAsync("access token");
            act.Should().Throw<ArgumentException>();
        }
    }
}
