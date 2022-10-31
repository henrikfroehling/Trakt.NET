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
    using Xunit;

    [TestCategory("Modules.Authentication")]
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
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RefreshAuthorizationAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

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
            await act.Should().ThrowAsync<ArgumentException>();

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
            await act.Should().ThrowAsync<ArgumentException>();

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
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = MockAuthorization;
            client.ClientId = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();
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
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();
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
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = TraktClientSecret;
            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();
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
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id", TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, "client secret");
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = null;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = string.Empty;

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authentication.RedirectUri = "redirect uri";

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();
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
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RedirectUri_Throws_AuthenticationOAuthException()
        {
            string errorJson = await TestUtility.SerializeObject(MockAuthorizationError);
            errorJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(REFRESH_AUTHORIZATION_URI, MockAuthorizationRefreshPostContent, errorJson, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, TraktRedirectUri);
            await act.Should().ThrowAsync<TraktAuthenticationOAuthException>().WithMessage(MockAuthorizationRefreshErrorMessage);
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RefreshAuthorization_With_Token_And_ClientId_And_ClientSecret_And_RediretUri_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.RefreshAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, null, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, string.Empty, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, "client id", TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, "client secret");
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RefreshAuthorizationAsync(TestConstants.MOCK_REFRESH_TOKEN, TraktClientId, TraktClientSecret, "redirect uri");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
