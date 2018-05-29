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
    using Xunit;

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        private const string REFRESH_AUTHORIZATION_URI = "oauth/token";

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);
            client.Authorization = MockAuthorization;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.RefreshAuthorizationAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_Throws_AuthenticationOAuthException_Unauthorized()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_AuthenticationOAuthException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = null,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = string.Empty,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = MockAuthorization;
            client.ClientId = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);
            client.Authorization = MockAuthorization;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = null,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = string.Empty,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = MockAuthorization;

            act = () => client.Authentication.RefreshAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);
            client.Authorization = MockAuthorization;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = null,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = string.Empty,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = MockAuthorization;

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id");
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);
            client.Authorization = MockAuthorization;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authentication.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = null,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = string.Empty,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = MockAuthorization;

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id", TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, "client secret");
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RediretUri()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, authorizationJson);
            client.Authorization = MockAuthorization;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.ExpiresInSeconds.Should().Be(MockAuthorization.ExpiresInSeconds);
            responseAuthorization.RefreshToken.Should().Be(TestConstants.MOCK_REFRESH_TOKEN);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.ExpiresInSeconds.Should().Be(responseAuthorization.ExpiresInSeconds);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RediretUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = null,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = string.Empty,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = TestConstants.MOCK_ACCESS_TOKEN,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 0,
                RefreshToken = "mock refresh token",
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthorizationException>();

            client.Authorization = MockAuthorization;

            act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id", TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, null, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, string.Empty, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, "client secret", TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, "redirect uri");
            act.Should().Throw<ArgumentException>();
        }
    }
}
