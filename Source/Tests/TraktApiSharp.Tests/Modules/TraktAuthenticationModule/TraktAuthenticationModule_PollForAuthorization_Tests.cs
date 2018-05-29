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
        private const string POLL_FOR_AUTHORIZATION_URI = "oauth/device/token";

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson);
            client.Authentication.Device = MockDevice;
            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync();

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

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_Polling()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authentication.Device = MockDevice;

            // First response: BadRequest => polling
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.BadRequest);

            // Second response: Ok => success
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.OK);

            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync();
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

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

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_AuthenticationDeviceException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_AuthenticationDeviceException_Conflict()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)412);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)422);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_AuthenticationDeviceException_RateLimit()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)429);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)503);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)504);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)520);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)521);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)522);
            client.Authentication.Device = MockDevice;
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();
            client.Authentication.Device = null;

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.Device = new TraktDevice
            {
                DeviceCode = null
            };

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.Device = new TraktDevice
            {
                DeviceCode = string.Empty,
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
            };

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.Device = new TraktDevice
            {
                DeviceCode = "mock device code",
                ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
            };

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            client.Authentication.Device = new TraktDevice
            {
                DeviceCode = MOCK_DEVICE_CODE
            };

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.Authentication.Device = MockDevice;
            client.ClientId = null;

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.PollForAuthorizationAsync();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice);

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

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_Polling()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();

            // First response: BadRequest => polling
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.BadRequest);

            // Second response: Ok => success
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.OK);

            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice);
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

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

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_AuthenticationDeviceException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_AuthenticationDeviceException_Conflict()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_AuthenticationDeviceException_RateLimit()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_With_Device_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                });
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                });
            act.Should().Throw<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = MOCK_DEVICE_CODE
                });
            act.Should().Throw<ArgumentException>();

            client.ClientId = null;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();

            client.ClientId = TraktClientId;
            client.ClientSecret = null;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);

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

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_Polling()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();

            // First response: BadRequest => polling
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.BadRequest);

            // Second response: Ok => success
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.OK);

            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

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

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_AuthenticationDeviceException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_AuthenticationDeviceException_Conflict()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_AuthenticationDeviceException_RateLimit()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(null, TraktClientId);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                TraktClientId);
            act.Should().Throw<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = MOCK_DEVICE_CODE
                },
                TraktClientId);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, "client id");
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = null;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = string.Empty;

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<ArgumentException>();

            client.ClientSecret = "client secret";

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_And_ClientSecret()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson);
            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);

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

        [Fact]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_And_ClientSecret_Polling()
        {
            string authorizationJson = await TestUtility.SerializeObject(MockAuthorization);
            authorizationJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetAuthenticationMockClient();

            // First response: BadRequest => polling
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.BadRequest);

            // Second response: Ok => success
            TestUtility.AddMockExpectationResponse((TestHttpClientProvider)client.HttpClientProvider, POLL_FOR_AUTHORIZATION_URI, MockAuthorizationPollingPostContent, authorizationJson, HttpStatusCode.OK);

            TraktResponse<ITraktAuthorization> response = await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            TestUtility.VerifyNoOutstandingExpectations((TestHttpClientProvider)client.HttpClientProvider);

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

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_AuthenticationDeviceException_NotFound()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_AuthenticationDeviceException_Conflict()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_AuthenticationDeviceException_RateLimit()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_WIth_Device_And_ClientId_And_ClientSecret_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_And_ClientSecret_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktAuthorization>>> act = () => client.Authentication.PollForAuthorizationAsync(null, TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = string.Empty,
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = "mock device code",
                    ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
                },
                TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
            act = () => client.Authentication.PollForAuthorizationAsync(
                new TraktDevice
                {
                    DeviceCode = MOCK_DEVICE_CODE
                },
                TraktClientId, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, null, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, string.Empty, TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, "client id", TraktClientSecret);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, "client secret");
            act.Should().Throw<ArgumentException>();
        }
    }
}
