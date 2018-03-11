namespace TraktApiSharp.Tests.Modules.TraktNetworksModule
{
    //using FluentAssertions;
    //using System;
    //using System.Linq;
    //using System.Net;
    //using System.Threading.Tasks;
    //using TestUtils;
    using Traits;
    //using TraktApiSharp.Exceptions;
    //using TraktApiSharp.Objects.Basic;
    //using TraktApiSharp.Responses;
    //using Xunit;

    [Category("Modules.Networks")]
    public partial class TraktNetworksModule_Tests
    {
        //private const string GET_NETWORKS_URL = "networks";

        //[Fact]
        //public async Task Test_TraktNetworksModule_GetNetworksAsync()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, GET_NETWORKS_JSON);

        //    TraktListResponse<ITraktNetwork> response = await TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();

        //    response.Should().NotBeNull();
        //    response.IsSuccess.Should().BeTrue();
        //    response.Value.Should().NotBeNull();
        //    response.HasValue.Should().BeTrue();
        //    response.Exception.Should().BeNull();
        //    response.Value.Should().NotBeEmpty().And.HaveCount(2);

        //    ITraktNetwork[] networks = response.ToArray();

        //    networks[0].Should().NotBeNull();
        //    networks[0].Network.Should().Be("ABC(US)");

        //    networks[1].Should().NotBeNull();
        //    networks[1].Network.Should().Be("The CW");

        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_NotFound()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.NotFound);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktNotFoundException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_Unauthorized()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.Unauthorized);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktAuthorizationException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_BadRequest()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.BadRequest);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktBadRequestException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_Forbidden()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.Forbidden);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktForbiddenException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_MethodNotAllowed()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.MethodNotAllowed);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktMethodNotFoundException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_Conflict()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.Conflict);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktConflictException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_InternalServerError()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.InternalServerError);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_BadGateway()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, HttpStatusCode.BadGateway);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktBadGatewayException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_412()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)412);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktPreconditionFailedException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_422()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)422);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktValidationException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_429()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)429);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktRateLimitException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_503()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)503);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_504()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)504);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_520()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)520);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_521()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)521);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act = () => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}

        //[Fact]
        //public void Test_TraktNetworksModule_GetNetworksAsync_Exceptions_HttpStatusCode_522()
        //{
        //    TestUtility.SetupMockHttpClient();
        //    TestUtility.SetupMockResponseWithoutOAuth(GET_NETWORKS_URL, (HttpStatusCode)522);
        //    Func<Task<TraktListResponse<ITraktNetwork>>> act =() => TestUtility.MOCK_TEST_CLIENT.Networks.GetNetworksAsync();
        //    act.Should().Throw<TraktServerUnavailableException>();
        //    TestUtility.ResetMockHttpClient();
        //}
    }
}
