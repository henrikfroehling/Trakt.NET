namespace TraktNet.Modules.Tests.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Authentication;
    using TraktNet.Responses;
    using TraktNet.Utils;
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
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
        public async Task Test_TraktAuthenticationModule_CheckIfAuthorizationIsExpiredOrWasRevoked_With_Authorization_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(CHECK_ACCESS_TOKEN_URI, statusCode);

            try
            {
                await client.Authentication.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(MockAuthorization);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
