#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBConfigurationGetRequestTests
    {
        [Fact]
        public void TestTMDBConfigurationGetRequestHasValidURIPath()
        {
            var configurationGetRequest = new TMDBConfigurationGetRequest();

            configurationGetRequest.BuildUri();
            configurationGetRequest.RequestUri.ShouldBe(new Uri("configuration", UriKind.Relative));
        }

        [Fact]
        public void TestTMDBConfigurationGetRequestIsGetRequest()
        {
            var configurationGetRequest = new TMDBConfigurationGetRequest();
            configurationGetRequest.Method.ShouldBe(HttpMethod.Get);
        }
    }
}
