namespace TraktApiSharp.Tests.Modules.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Authentication;
    using TraktApiSharp.Responses;
    using TraktApiSharp.Utils;
    using Xunit;

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Success()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, SYNC_LAST_ACTIVITIES_JSON);
            client.Authorization = MockAuthorization;
            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();

            response.Should().NotBeNull();
            response.First.Should().BeFalse();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Success()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, SYNC_LAST_ACTIVITIES_JSON);
            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);

            response.Should().NotBeNull();
            response.First.Should().BeFalse();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Failed_Expired()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, SYNC_LAST_ACTIVITIES_JSON);

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Failed_Expired()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, SYNC_LAST_ACTIVITIES_JSON);

            ITraktAuthorization authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization);

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Failed_Revoked()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;
            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Failed_Revoked()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Unauthorized);
            Pair<bool, TraktResponse<ITraktAuthorization>> response = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);

            response.Should().NotBeNull();
            response.First.Should().BeTrue();
            response.Second.Should().NotBeNull();
            response.Second.IsSuccess.Should().BeFalse();
            response.Second.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Failed_Revoked_AutoRefresh()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = MockAuthorization;

            // First response, if authorization was revoked
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Unauthorized);

            // Second response for autoRefresh == true
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, GET_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);

            Pair<bool, TraktResponse<ITraktAuthorization>> responseValues = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(true);
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

            responseValues.Should().NotBeNull();
            responseValues.First.Should().BeTrue();

            TraktResponse<ITraktAuthorization> response = responseValues.Second;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(MockAuthorization.RefreshToken);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAccessToken = client.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAccessToken.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAccessToken.Scope.Should().Be(responseAuthorization.Scope);
            clientAccessToken.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Failed_Revoked_AutoRefresh()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();

            // First response, if authorization was revoked
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Unauthorized);

            // Second response for autoRefresh == true
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, GET_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);

            Pair<bool, TraktResponse<ITraktAuthorization>> responseValues = await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization, true);
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

            responseValues.Should().NotBeNull();
            responseValues.First.Should().BeTrue();

            TraktResponse<ITraktAuthorization> response = responseValues.Second;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(MockAuthorization.RefreshToken);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAccessToken = client.Authorization;

            clientAccessToken.Should().NotBeNull();
            clientAccessToken.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAccessToken.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAccessToken.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAccessToken.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAccessToken.Scope.Should().Be(responseAuthorization.Scope);
            clientAccessToken.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAccessToken.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.NotFound);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadRequest);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Forbidden);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.Conflict);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.InternalServerError);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, HttpStatusCode.BadGateway);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)412);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)422);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)429);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)503);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)504);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)520);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)521);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, (HttpStatusCode)522);
            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<Pair<bool, TraktResponse<ITraktAuthorization>>>> act = () => client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(null);
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
