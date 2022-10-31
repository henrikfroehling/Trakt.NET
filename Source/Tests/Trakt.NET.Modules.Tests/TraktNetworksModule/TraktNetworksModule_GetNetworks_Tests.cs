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

    [TestCategory("Modules.Networks")]
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
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
        public async Task Test_TraktNetworksModule_GetNetworks_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_NETWORKS_URI, statusCode);

            try
            {
                await client.Networks.GetNetworksAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
