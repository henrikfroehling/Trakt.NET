namespace TraktNet.Tests.Modules.TraktAuthenticationModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
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
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_AuthenticationException_Unauthorized()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_AuthenticationException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authorization = new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(TestConstants.CREATED_AT),
                TokenType = TraktAccessTokenType.Bearer,
                ExpiresInSeconds = 7200,
                Scope = TraktAccessScope.Public
            };

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

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
            act.Should().Throw<ArgumentException>();

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
            act.Should().Throw<ArgumentException>();

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
            act.Should().Throw<ArgumentException>();

            client.Authorization = MockAuthorization;
            client.ClientId = null;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.RevokeAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
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
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_AuthenticationException_Unauthorized()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_AuthenticationException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync("mock refresh token");
            act.Should().Throw<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client id";

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN);
            act.Should().Throw<ArgumentException>();
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
            authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            authorization.ExpiresInSeconds.Should().Be(7776000U);
            authorization.IsExpired.Should().BeTrue();
            authorization.IsRefreshPossible.Should().BeFalse();
            authorization.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_AuthenticationException_Unauthorized()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_AuthenticationException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktAuthenticationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadRequest);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(REVOKE_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authorization = MockAuthorization;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_RevokeAuthorization_With_Token_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authorization = null;

            Func<Task<TraktNoContentResponse>> act = () => client.Authentication.RevokeAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(string.Empty, TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync("mock refresh token", TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.RevokeAuthorizationAsync(TestConstants.MOCK_ACCESS_TOKEN, "client id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
