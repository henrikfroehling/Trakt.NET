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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
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
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authentication.OAuthAuthorizationCode = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = "mock auth code";

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.OAuthAuthorizationCode = MOCK_AUTH_CODE;
            client.ClientId = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
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
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE);
            await act.Should().ThrowAsync<ArgumentException>();
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
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
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
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
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id", TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, "client secret");
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();
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
            responseAuthorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
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
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GetAuthorization_With_Code_And_ClientId_And_ClientSecret_And_RedirectUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.GetAuthorizationAsync(null, TraktClientId, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync("mock auth code", TraktClientId, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, null, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, string.Empty, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, "client id", TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, null, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, string.Empty, TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, "client secret", TraktRedirectUri);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.GetAuthorizationAsync(MOCK_AUTH_CODE, TraktClientId, TraktClientSecret, "redirect uri");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
