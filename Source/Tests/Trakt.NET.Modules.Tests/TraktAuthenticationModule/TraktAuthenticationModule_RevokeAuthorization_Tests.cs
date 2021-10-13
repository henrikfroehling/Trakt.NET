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

    [Category("Modules.Authentication")]
    public partial class TraktAuthenticationModule_Tests
    {
        private const string REVOKE_AUTHORIZATION_URI = "oauth/revoke";

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, MockAuthorizationRevokePostContent);
            client.Authorization = MockAuthorization;
            TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();

            ITraktAuthorization authorization = client.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthenticationException))]
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
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RevokeAuthorizationAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = null,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = string.Empty,
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                AccessToken = "mock access token",
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                RefreshToken = TestConstants.MOCK_REFRESH_TOKEN,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.Authorization = MockAuthorization;
            client.ClientId = null;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RevokeAuthorizationAsync();
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, MockAuthorizationRevokePostContent);
            client.Authorization = MockAuthorization;
            TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();

            ITraktAuthorization authorization = client.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthenticationException))]
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
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync("mock refresh token");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, MockAuthorizationRevokePostContent);
            client.Authorization = MockAuthorization;
            TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();

            ITraktAuthorization authorization = client.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthenticationException))]
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
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(null, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(string.Empty, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync("mock refresh token", TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, "client id");
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            await act.Should().ThrowAsync<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_And_ClientSecret()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, MockAuthorizationRevokePostContent);
            client.Authorization = MockAuthorization;
            TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId, TraktClientSecret);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();

            ITraktAuthorization authorization = client.Authorization;
            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.Scope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(3600));
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthenticationException))]
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
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_And_ClientSecret_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, statusCode);
            client.Authorization = MockAuthorization;

            try
            {
                await client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId, TraktClientSecret);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(string.Empty, TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync("mock refresh token", TraktClientId, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, null, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, string.Empty, TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, "client id", TraktClientSecret);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId, "client secret");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
