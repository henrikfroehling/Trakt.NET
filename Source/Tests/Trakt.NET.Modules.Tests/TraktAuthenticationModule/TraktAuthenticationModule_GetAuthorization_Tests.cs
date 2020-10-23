namespace TraktNet.Modules.Tests.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Authentication;
    using TraktNet.Responses;
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationOAuthException))]
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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, statusCode);
            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;

            try
            {
                await client.Authentication.GetAuthorizationAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationOAuthException))]
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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationOAuthException))]
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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationOAuthException))]
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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationOAuthException))]
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
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, TraktRedirectUri);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
