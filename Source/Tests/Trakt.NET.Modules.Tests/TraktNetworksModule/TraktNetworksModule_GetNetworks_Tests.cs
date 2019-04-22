namespace TraktNet.Modules.Tests.TraktNetworksModule
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Networks")]
    public partial class TraktNetworksModule_Tests
    {
        private const string GET_NETWORKS_URI = "networks";

        [Fact]
        public async Task Test_TraktNetworksModule_GetNetworks()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, GET_NETWORKS_JSON);
            TraktListResponse<ITraktNetwork> response = await client.Networks.GetNetworksAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.Value.Should().NotBeNull();
            response.HasValue.Should().BeTrue();
            response.Exception.Should().BeNull();
            response.Value.Should().NotBeEmpty().And.HaveCount(2);

            ITraktNetwork[] networks = response.ToArray();

            networks[0].Should().NotBeNull();
            networks[0].Name.Should().Be("ABC(US)");

            networks[1].Should().NotBeNull();
            networks[1].Name.Should().Be("The CW");
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktNetworksModule_GetNetworks_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktNetwork>>> act = () => client.Networks.GetNetworksAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
