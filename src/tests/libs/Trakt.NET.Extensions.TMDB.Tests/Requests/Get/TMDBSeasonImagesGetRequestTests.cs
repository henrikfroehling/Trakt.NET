#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBSeasonImagesGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/season/{TMDBTestConstants.Seasons.SeasonNrString}/images";

        [Fact]
        public void TestTMDBSeasonImagesGetRequestHasValidURIPath()
        {
            var seasonImagesGetRequest = new TMDBSeasonImagesGetRequest {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            seasonImagesGetRequest.BuildUri();
            seasonImagesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBSeasonImagesGetRequestIsGetRequest()
        {
            var seasonImagesGetRequest = new TMDBSeasonImagesGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            seasonImagesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBSeasonImagesGetRequestValidate()
        {
            var seasonImagesGetRequest = new TMDBSeasonImagesGetRequest
            {
                Id = 0,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            Action act = () => seasonImagesGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
