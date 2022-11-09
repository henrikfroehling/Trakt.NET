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
    }
}
