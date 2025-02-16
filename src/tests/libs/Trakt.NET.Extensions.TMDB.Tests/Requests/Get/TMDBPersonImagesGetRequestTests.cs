#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBPersonImagesGetRequestTests
    {
        private const string URIPath = $"person/{TMDBTestConstants.People.PersonIDString}/images";

        [Fact]
        public void TestTMDBPersonImagesGetRequestHasValidURIPath()
        {
            var personImagesGetRequest = new TMDBPersonImagesGetRequest { Id = TMDBTestConstants.People.PersonID };

            personImagesGetRequest.BuildUri();
            personImagesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBPersonImagesGetRequestIsGetRequest()
        {
            var personImagesGetRequest = new TMDBPersonImagesGetRequest { Id = TMDBTestConstants.People.PersonID };
            personImagesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBPersonImagesGetRequestValidate()
        {
            var personImagesGetRequest = new TMDBPersonImagesGetRequest { Id = 0 };

            Action act = () => personImagesGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
