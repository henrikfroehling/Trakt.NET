#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBShowVideosGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/videos";

        [Fact]
        public void TestTMDBShowVideosGetRequestHasValidURIPath()
        {
            var showVideosGetRequest = new TMDBShowVideosGetRequest { Id = TMDBTestConstants.Shows.ShowID };

            showVideosGetRequest.BuildUri();
            showVideosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBShowVideosGetRequestIsGetRequest()
        {
            var showVideosGetRequest = new TMDBShowVideosGetRequest { Id = TMDBTestConstants.Shows.ShowID };
            showVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBShowVideosGetRequestValidate()
        {
            var showVideosGetRequest = new TMDBShowVideosGetRequest { Id = 0 };

            Action act = () => showVideosGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
