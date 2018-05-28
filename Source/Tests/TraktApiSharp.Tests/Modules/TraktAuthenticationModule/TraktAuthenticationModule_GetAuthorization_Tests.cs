namespace TraktApiSharp.Tests.Modules.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Authentication;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        private const string GET_AUTHORIZATION_URI = "oauth/token";

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, authorizationJson);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.GetAuthorizationAsync();

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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authentication.OAuthAuthorizationCode = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = "mock auth code";

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;
            client.ClientId = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.RefreshToken.Should().Be(MockAuthorization.RefreshToken);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code");
            act.Should().Throw<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);

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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id");
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktAuthorization responseAuthorization = response.Value;

            responseAuthorization.Should().NotBeNull();
            responseAuthorization.AccessToken.Should().Be(MockAuthorization.AccessToken);
            responseAuthorization.TokenType.Should().Be(MockAuthorization.TokenType);
            responseAuthorization.RefreshToken.Should().Be(MockAuthorization.RefreshToken);
            responseAuthorization.Scope.Should().Be(MockAuthorization.Scope);
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
            responseAuthorization.IsExpired.Should().BeFalse();

            ITraktAuthorization clientAuthorization = client.Authorization;

            clientAuthorization.Should().NotBeNull();
            clientAuthorization.AccessToken.Should().Be(responseAuthorization.AccessToken);
            clientAuthorization.TokenType.Should().Be(responseAuthorization.TokenType);
            clientAuthorization.RefreshToken.Should().Be(responseAuthorization.RefreshToken);
            clientAuthorization.Scope.Should().Be(responseAuthorization.Scope);
            clientAuthorization.CreatedAt.Should().Be(responseAuthorization.CreatedAt);
            clientAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id", TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, "client secret");
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);

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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, MockAuthorizationPostContent, errorJson, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktAuthenticationOAuthException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty, TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id", TraktClientSecret, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, null, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, string.Empty, TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, "client secret", TraktRedirectUri);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, "redirect uri");
            act.Should().Throw<ArgumentException>();
        }
    }
}
