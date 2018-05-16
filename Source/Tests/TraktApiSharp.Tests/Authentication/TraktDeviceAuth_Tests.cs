namespace TraktApiSharp.Tests.Authentication
{
    //using FluentAssertions;
    //using Newtonsoft.Json;
    //using System;
    //using System.Net;
    //using System.Threading;
    //using System.Threading.Tasks;
    //using TestUtils;
    using Traits;
    //using TraktApiSharp.Core;
    //using TraktApiSharp.Enums;
    //using TraktApiSharp.Exceptions;
    //using TraktApiSharp.Objects.Authentication.Implementations;
    //using TraktApiSharp.Objects.Basic.Implementations;
    //using Xunit;

    [Category("Authentication")]
    public class TraktDeviceAuth_Tests
    {
        //[Fact]
        //public void Test_TraktDeviceAuth_DefaultConstructor()
        //{
        //    var client = new TraktClient();

        //    client.DeviceAuth.Client.Should().Be(client);
        //}

        //// -----------------------------------------------------------------------------------------------
        //// -----------------------------------------------------------------------------------------------

        //#region GenerateDevice

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDevice()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = 600,
        //        IntervalInSeconds = 5
        //    };

        //    var deviceJson = JsonConvert.SerializeObject(device);
        //    deviceJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceCodeUri, postContent, deviceJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync().Result;

        //    response.Should().NotBeNull();
        //    response.DeviceCode.Should().Be(device.DeviceCode);
        //    response.UserCode.Should().Be(device.UserCode);
        //    response.VerificationUrl.Should().Be(device.VerificationUrl);
        //    response.ExpiresInSeconds.Should().Be(device.ExpiresInSeconds);
        //    response.IntervalInSeconds.Should().Be(device.IntervalInSeconds);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpiredUnused.Should().BeFalse();
        //    response.IsValid.Should().BeTrue();

        //    var clientDevice = TestUtility.MOCK_TEST_CLIENT.Authentication.Device;

        //    clientDevice.Should().NotBeNull();
        //    clientDevice.DeviceCode.Should().Be(response.DeviceCode);
        //    clientDevice.UserCode.Should().Be(response.UserCode);
        //    clientDevice.VerificationUrl.Should().Be(response.VerificationUrl);
        //    clientDevice.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientDevice.IntervalInSeconds.Should().Be(response.IntervalInSeconds);
        //    clientDevice.CreatedAt.Should().Be(response.CreatedAt);
        //    clientDevice.IsExpiredUnused.Should().BeFalse();
        //    clientDevice.IsValid.Should().BeTrue();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDeviceExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var uri = Constants.OAuthDeviceCodeUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDeviceArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDeviceWithClientId()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = 600,
        //        IntervalInSeconds = 5
        //    };

        //    var deviceJson = JsonConvert.SerializeObject(device);
        //    deviceJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"client_id\": \"{clientId}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceCodeUri, postContent, deviceJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId).Result;

        //    response.Should().NotBeNull();
        //    response.DeviceCode.Should().Be(device.DeviceCode);
        //    response.UserCode.Should().Be(device.UserCode);
        //    response.VerificationUrl.Should().Be(device.VerificationUrl);
        //    response.ExpiresInSeconds.Should().Be(device.ExpiresInSeconds);
        //    response.IntervalInSeconds.Should().Be(device.IntervalInSeconds);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpiredUnused.Should().BeFalse();
        //    response.IsValid.Should().BeTrue();

        //    var clientDevice = TestUtility.MOCK_TEST_CLIENT.Authentication.Device;

        //    clientDevice.Should().NotBeNull();
        //    clientDevice.DeviceCode.Should().Be(response.DeviceCode);
        //    clientDevice.UserCode.Should().Be(response.UserCode);
        //    clientDevice.VerificationUrl.Should().Be(response.VerificationUrl);
        //    clientDevice.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientDevice.IntervalInSeconds.Should().Be(response.IntervalInSeconds);
        //    clientDevice.CreatedAt.Should().Be(response.CreatedAt);
        //    clientDevice.IsExpiredUnused.Should().BeFalse();
        //    clientDevice.IsValid.Should().BeTrue();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDeviceWithClientIdExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";

        //    var uri = Constants.OAuthDeviceCodeUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_GenerateDeviceWithClientIdArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    Func<Task<TraktDevice>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    var clientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.GenerateDeviceAsync(clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //#endregion

        //// -----------------------------------------------------------------------------------------------
        //// -----------------------------------------------------------------------------------------------

        //#region PollForAuthorization

        //private const uint DEVICE_EXPIRES_IN_SECONDS = 60;
        //private const uint DEVICE_INTERVAL_IN_SECONDS = 6;
        //private const uint POLLING_DELAY_IN_MILLISECONDS = 9 * 1000;

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorization()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };
            
        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson);
        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync().Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //// Run this test only individually
        ////[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationPolling()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

        //    var timer = new Timer(x =>
        //    {
        //        //Debug.WriteLine("Delayed Http Status Code Change");
        //        TestUtility.ClearMockHttpClient();
        //        TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
        //    }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync().Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var uri = Constants.OAuthDeviceTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = null };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice
        //    {
        //        DeviceCode = string.Empty,
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //    };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice
        //    {
        //        DeviceCode = "mock device code",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //    };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = new TraktDevice { DeviceCode = "mockDeviceCode" };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.Device = device;
        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDevice()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //// Run this test only individually
        ////[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDevicePolling()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

        //    var timer = new Timer(x =>
        //    {
        //        //Debug.WriteLine("Delayed Http Status Code Change");
        //        TestUtility.ClearMockHttpClient();
        //        TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
        //    }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var uri = Constants.OAuthDeviceTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null);
        //    act.Should().Throw<ArgumentNullException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = string.Empty,
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        });
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = "mock device code",
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        });
        //    act.Should().Throw<ArgumentException>();

        //    // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice { DeviceCode = "mockDeviceCode" });
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientId()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //// Run this test only individually
        ////[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdPolling()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

        //    var timer = new Timer(x =>
        //    {
        //        //Debug.WriteLine("Delayed Http Status Code Change");
        //        TestUtility.ClearMockHttpClient();
        //        TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
        //    }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var clientId = "clientId";

        //    var uri = Constants.OAuthDeviceTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationithDeviceAndClientIdArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var clientId = "clientId";

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null, clientId);
        //    act.Should().Throw<ArgumentNullException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = string.Empty,
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        }, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = "mock device code",
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        }, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice { DeviceCode = "mockDeviceCode" }, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    clientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    clientId = "clientId";
        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdAndClientSecret()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //// Run this test only individually
        ////[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdAndClientSecretPolling()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var postContent = $"{{ \"code\": \"{device.DeviceCode}\", \"client_id\": \"{clientId}\", \"client_secret\": \"{clientSecret}\" }}";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.BadRequest);

        //    var timer = new Timer(x =>
        //    {
        //        //Debug.WriteLine("Delayed Http Status Code Change");
        //        TestUtility.ClearMockHttpClient();
        //        TestUtility.SetupMockAuthenticationResponse(Constants.OAuthDeviceTokenUri, postContent, accessTokenJson, HttpStatusCode.OK);
        //    }, null, POLLING_DELAY_IN_MILLISECONDS, POLLING_DELAY_IN_MILLISECONDS);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdAndClientSecretExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";

        //    var uri = Constants.OAuthDeviceTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Gone);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)418);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationDeviceException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_PollForAuthorizationWithDeviceAndClientIdAndClientSecretArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var device = new TraktDevice
        //    {
        //        DeviceCode = "mockDeviceCode",
        //        UserCode = "5055CC52",
        //        VerificationUrl = "https://trakt.tv/activate",
        //        ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS,
        //        IntervalInSeconds = DEVICE_INTERVAL_IN_SECONDS
        //    };

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<ArgumentNullException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = string.Empty,
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        },
        //        clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice
        //        {
        //            DeviceCode = "mock device code",
        //            ExpiresInSeconds = DEVICE_EXPIRES_IN_SECONDS
        //        },
        //        clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    // ExpiredUnused == true, because of ExpiresInSeconds defaults to 0
        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(
        //        new TraktDevice { DeviceCode = "mockDeviceCode" },
        //        clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, null, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, string.Empty, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    clientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    clientId = "clientId";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    clientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.PollForAuthorizationAsync(device, clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //#endregion

        //// -----------------------------------------------------------------------------------------------
        //// -----------------------------------------------------------------------------------------------

        //#region RefreshAuthorization

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorization()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync().Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var error = new TraktError
        //    {
        //        Error = "invalid_grant",
        //        Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
        //    };

        //    var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
        //                       $"description: {error.Description}";

        //    var errorJson = JsonConvert.SerializeObject(error);
        //    errorJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    var uri = Constants.OAuthTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithToken()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var error = new TraktError
        //    {
        //        Error = "invalid_grant",
        //        Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
        //    };

        //    var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
        //                       $"description: {error.Description}";

        //    var errorJson = JsonConvert.SerializeObject(error);
        //    errorJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    var uri = Constants.OAuthTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "clientId";
        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientId()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = TestUtility.MOCK_TEST_CLIENT.ClientSecret;
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var error = new TraktError
        //    {
        //        Error = "invalid_grant",
        //        Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
        //    };

        //    var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
        //                       $"description: {error.Description}";

        //    var errorJson = JsonConvert.SerializeObject(error);
        //    errorJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    var uri = Constants.OAuthTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var clientId = "clientId";

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "client secret";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientSecret = "clientSecret";
        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecret()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken,
        //                                                                                   clientId, clientSecret).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecretExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";
        //    var redirectUri = TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri;
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var error = new TraktError
        //    {
        //        Error = "invalid_grant",
        //        Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
        //    };

        //    var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
        //                       $"description: {error.Description}";

        //    var errorJson = JsonConvert.SerializeObject(error);
        //    errorJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    var uri = Constants.OAuthTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecretArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authentication.RedirectUri = "redirect uri";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUri()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";
        //    var redirectUri = "redirectUri";
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var accessTokenJson = JsonConvert.SerializeObject(accessToken);
        //    accessTokenJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    TestUtility.SetupMockAuthenticationResponse(Constants.OAuthTokenUri, postContent, accessTokenJson);

        //    var response = TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken,
        //                                                                                   clientId, clientSecret,
        //                                                                                   redirectUri).Result;

        //    response.Should().NotBeNull();
        //    response.AccessToken.Should().Be(accessToken.AccessToken);
        //    response.TokenType.Should().Be(accessToken.TokenType);
        //    response.ExpiresInSeconds.Should().Be(accessToken.ExpiresInSeconds);
        //    response.RefreshToken.Should().Be(accessToken.RefreshToken);
        //    response.Scope.Should().Be(accessToken.Scope);
        //    response.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1800 * 1000);
        //    response.IsExpired.Should().BeFalse();

        //    var clientAccessToken = TestUtility.MOCK_TEST_CLIENT.Authorization;

        //    clientAccessToken.Should().NotBeNull();
        //    clientAccessToken.AccessToken.Should().Be(response.AccessToken);
        //    clientAccessToken.TokenType.Should().Be(response.TokenType);
        //    clientAccessToken.ExpiresInSeconds.Should().Be(response.ExpiresInSeconds);
        //    clientAccessToken.RefreshToken.Should().Be(response.RefreshToken);
        //    clientAccessToken.Scope.Should().Be(response.Scope);
        //    clientAccessToken.CreatedAt.Should().Be(response.CreatedAt);
        //    clientAccessToken.IsExpired.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";
        //    var redirectUri = "redirectUri";
        //    var grantType = TraktAccessTokenGrantType.RefreshToken.ObjectName;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var error = new TraktError
        //    {
        //        Error = "invalid_grant",
        //        Description = "The provided authorization grant is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client."
        //    };

        //    var errorMessage = $"error on refreshing oauth access token\nerror: {error.Error}\n" +
        //                       $"description: {error.Description}";

        //    var errorJson = JsonConvert.SerializeObject(error);
        //    errorJson.Should().NotBeNullOrEmpty();

        //    var postContent = $"{{ \"refresh_token\": \"{accessToken.RefreshToken}\", \"client_id\": \"{clientId}\", " +
        //                      $"\"client_secret\": \"{clientSecret}\", \"redirect_uri\": " +
        //                      $"\"{redirectUri}\", \"grant_type\": \"{grantType}\" }}";

        //    var uri = Constants.OAuthTokenUri;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, postContent, errorJson, HttpStatusCode.Unauthorized);
        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthenticationException>().WithMessage(errorMessage);

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RefreshAuthorizationWithTokenAndClientIdAndClientSecretAndRedirectUriArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var clientId = "clientId";
        //    var clientSecret = "clientSecret";
        //    var redirectUri = "redirectUri";

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task<TraktAuthorization>> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(null, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(string.Empty, clientId, clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync("mock refresh token", clientId, clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, null, clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, string.Empty, clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, "client id", clientSecret, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, null, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty, redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "client secret", redirectUri);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, clientSecret, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RefreshAuthorizationAsync(accessToken.RefreshToken, clientId, "redirect uri");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //#endregion

        //// -----------------------------------------------------------------------------------------------
        //// -----------------------------------------------------------------------------------------------

        //#region RevokeAuthorization

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorization()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var postContent = $"token={accessToken.AccessToken}";

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
        //    TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().NotThrow();

        //    var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
        //    authorization.Should().NotBeNull();
        //    authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.Scope.Should().Be(TraktAccessScope.Public);
        //    authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
        //    authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1000);
        //    authorization.ExpiresInSeconds.Should().Be(0);
        //    authorization.IgnoreExpiration.Should().BeTrue();
        //    authorization.IsExpired.Should().BeTrue();
        //    authorization.IsRefreshPossible.Should().BeFalse();
        //    authorization.IsValid.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthenticationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync();
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithToken()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var postContent = $"token={accessToken.AccessToken}";

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
        //    TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().NotThrow();

        //    var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
        //    authorization.Should().NotBeNull();
        //    authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.Scope.Should().Be(TraktAccessScope.Public);
        //    authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
        //    authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1000);
        //    authorization.ExpiresInSeconds.Should().Be(0);
        //    authorization.IgnoreExpiration.Should().BeTrue();
        //    authorization.IsExpired.Should().BeTrue();
        //    authorization.IsRefreshPossible.Should().BeFalse();
        //    authorization.IsValid.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithTokenExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktAuthenticationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithTokenArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = null;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = string.Empty;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.MOCK_TEST_CLIENT.ClientId = "client id";

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken);
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithTokenAndClientId()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = TestUtility.MOCK_TEST_CLIENT.ClientId;

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var postContent = $"token={accessToken.AccessToken}";

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;
        //    TestUtility.SetupMockAuthenticationTokenRevokeResponse(uri, postContent);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().NotThrow();

        //    var authorization = TestUtility.MOCK_TEST_CLIENT.Authorization;
        //    authorization.Should().NotBeNull();
        //    authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
        //    authorization.Scope.Should().Be(TraktAccessScope.Public);
        //    authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
        //    authorization.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, 1000);
        //    authorization.ExpiresInSeconds.Should().Be(0);
        //    authorization.IgnoreExpiration.Should().BeTrue();
        //    authorization.IsExpired.Should().BeTrue();
        //    authorization.IsRefreshPossible.Should().BeFalse();
        //    authorization.IsValid.Should().BeFalse();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithTokenAndClientIdExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var clientId = "clientId";

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var uri = Constants.OAuthRevokeUri;

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Unauthorized);

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktAuthenticationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.NotFound);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadRequest);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktBadRequestException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Conflict);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktConflictException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.Forbidden);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktForbiddenException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.MethodNotAllowed);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktMethodNotFoundException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.InternalServerError);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, HttpStatusCode.BadGateway);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktBadGatewayException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)412);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktPreconditionFailedException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)422);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktValidationException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)429);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktRateLimitException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)503);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)504);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)520);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)521);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.SetupMockAuthenticationErrorResponse(uri, (HttpStatusCode)522);

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.AccessToken, clientId);
        //    act.Should().Throw<TraktServerUnavailableException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //[Fact]
        //public void Test_TraktDeviceAuth_RevokeAuthorizationWithTokenAndClientIdArgumentExceptions()
        //{
        //    TestUtility.SetupMockAuthenticationHttpClient();

        //    var accessToken = new TraktAuthorization
        //    {
        //        AccessToken = "mockAccessToken",
        //        TokenType = TraktAccessTokenType.Bearer,
        //        ExpiresInSeconds = 7200,
        //        RefreshToken = "mockRefreshToken",
        //        Scope = TraktAccessScope.Public
        //    };

        //    var clientId = "clientId";

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = null;

        //    Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = null, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = string.Empty, ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 7200 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = new TraktAuthorization { RefreshToken = "mock refresh token", ExpiresInSeconds = 0 };

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<TraktAuthorizationException>();

        //    TestUtility.MOCK_TEST_CLIENT.Authorization = accessToken;

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(null, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(string.Empty, clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync("mock refresh token", clientId);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, null);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, string.Empty);
        //    act.Should().Throw<ArgumentException>();

        //    act = async () => await TestUtility.MOCK_TEST_CLIENT.DeviceAuth.RevokeAuthorizationAsync(accessToken.RefreshToken, "client id");
        //    act.Should().Throw<ArgumentException>();

        //    TestUtility.ClearMockHttpClient();
        //    TestUtility.SetDefaultClientValues();
        //}

        //#endregion
    }
}
