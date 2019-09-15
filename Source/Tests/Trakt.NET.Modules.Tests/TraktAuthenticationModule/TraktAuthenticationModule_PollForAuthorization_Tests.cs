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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, statusCode);
            client.Authentication.Device = MockDevice;

            try
            {
                await client.Authentication.PollForAuthorizationAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_Wíth_Device_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.PollForAuthorizationAsync(MockDevice);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktAuthenticationDeviceException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktAuthenticationModule_PollForAuthorization_With_Device_And_ClientId_And_ClientSecret_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(POLL_FOR_AUTHORIZATION_URI, statusCode);

            try
            {
                await client.Authentication.PollForAuthorizationAsync(MockDevice, TraktClientId, TraktClientSecret);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
