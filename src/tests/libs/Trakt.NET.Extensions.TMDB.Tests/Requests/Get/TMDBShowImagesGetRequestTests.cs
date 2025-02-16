#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBShowImagesGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/images";

        [Fact]
        public void TestTMDBShowImagesGetRequestHasValidURIPath()
        {
            var showImagesGetRequest = new TMDBShowImagesGetRequest { Id = TMDBTestConstants.Shows.ShowID };

            showImagesGetRequest.BuildUri();
            showImagesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBShowImagesGetRequestIsGetRequest()
        {
            var showImagesGetRequest = new TMDBShowImagesGetRequest { Id = TMDBTestConstants.Shows.ShowID };
            showImagesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBShowImagesGetRequestValidate()
        {
            var showImagesGetRequest = new TMDBShowImagesGetRequest { Id = 0 };

            Action act = () => showImagesGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
