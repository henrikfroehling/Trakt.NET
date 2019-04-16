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
        private const string GET_DEVICE_URI = "oauth/device/code";

        [Fact]
        public async Task Test_TraktAuthenticationModule_GenerateDevice()
        {
            string deviceJson = await TestUtility.SerializeObject(MockDevice);
            deviceJson.Should().NotBeNullOrEmpty();

            string postContent = $"{{ \"client_id\": \"{TestConstants.TRAKT_CLIENT_ID}\" }}";
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, postContent, deviceJson);
            TraktResponse<ITraktDevice> response = await client.Authentication.GenerateDeviceAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktDevice responseDevice = response.Value;

            responseDevice.Should().NotBeNull();
            responseDevice.DeviceCode.Should().Be(MockDevice.DeviceCode);
            responseDevice.UserCode.Should().Be(MockDevice.UserCode);
            responseDevice.VerificationUrl.Should().Be(MockDevice.VerificationUrl);
            responseDevice.ExpiresInSeconds.Should().Be(MockDevice.ExpiresInSeconds);
            responseDevice.IntervalInSeconds.Should().Be(MockDevice.IntervalInSeconds);
            responseDevice.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseDevice.IsExpiredUnused.Should().BeFalse();
            responseDevice.IsValid.Should().BeTrue();

            ITraktDevice clientDevice = client.Authentication.Device;

            clientDevice.Should().NotBeNull();
            clientDevice.DeviceCode.Should().Be(responseDevice.DeviceCode);
            clientDevice.UserCode.Should().Be(responseDevice.UserCode);
            clientDevice.VerificationUrl.Should().Be(responseDevice.VerificationUrl);
            clientDevice.ExpiresInSeconds.Should().Be(responseDevice.ExpiresInSeconds);
            clientDevice.IntervalInSeconds.Should().Be(responseDevice.IntervalInSeconds);
            clientDevice.CreatedAt.Should().Be(responseDevice.CreatedAt);
            clientDevice.IsExpiredUnused.Should().BeFalse();
            clientDevice.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_AuthenticationDeviceException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            client.ClientId = null;

            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = string.Empty;

            act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<ArgumentException>();

            client.ClientId = "client id";

            act = () => client.Authentication.GenerateDeviceAsync();
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public async Task Test_TraktAuthenticationModule_GenerateDevice_With_ClientId()
        {
            string deviceJson = await TestUtility.SerializeObject(MockDevice);
            deviceJson.Should().NotBeNullOrEmpty();

            string postContent = $"{{ \"client_id\": \"{TestConstants.TRAKT_CLIENT_ID}\" }}";
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, postContent, deviceJson);
            TraktResponse<ITraktDevice> response = await client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktDevice responseDevice = response.Value;

            responseDevice.Should().NotBeNull();
            responseDevice.DeviceCode.Should().Be(MockDevice.DeviceCode);
            responseDevice.UserCode.Should().Be(MockDevice.UserCode);
            responseDevice.VerificationUrl.Should().Be(MockDevice.VerificationUrl);
            responseDevice.ExpiresInSeconds.Should().Be(MockDevice.ExpiresInSeconds);
            responseDevice.IntervalInSeconds.Should().Be(MockDevice.IntervalInSeconds);
            responseDevice.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, CLOSE_TO_PRECISION);
            responseDevice.IsExpiredUnused.Should().BeFalse();
            responseDevice.IsValid.Should().BeTrue();

            ITraktDevice clientDevice = client.Authentication.Device;

            clientDevice.Should().NotBeNull();
            clientDevice.DeviceCode.Should().Be(responseDevice.DeviceCode);
            clientDevice.UserCode.Should().Be(responseDevice.UserCode);
            clientDevice.VerificationUrl.Should().Be(responseDevice.VerificationUrl);
            clientDevice.ExpiresInSeconds.Should().Be(responseDevice.ExpiresInSeconds);
            clientDevice.IntervalInSeconds.Should().Be(responseDevice.IntervalInSeconds);
            clientDevice.CreatedAt.Should().Be(responseDevice.CreatedAt);
            clientDevice.IsExpiredUnused.Should().BeFalse();
            clientDevice.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_AuthenticationDeviceException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktAuthenticationDeviceException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient(GET_DEVICE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(TestConstants.TRAKT_CLIENT_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktAuthenticationModule_GenerateDevice_With_ClientId_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetAuthenticationMockClient();

            Func<Task<TraktResponse<ITraktDevice>>> act = () => client.Authentication.GenerateDeviceAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GenerateDeviceAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Authentication.GenerateDeviceAsync("client id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
