#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBSeasonVideosGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/season/{TMDBTestConstants.Seasons.SeasonNrString}/videos";

        [Fact]
        public void TestTMDBSeasonVideosGetRequestHasValidURIPath()
        {
            var seasonVideosGetRequest = new TMDBSeasonVideosGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            seasonVideosGetRequest.BuildUri();
            seasonVideosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBSeasonVideosGetRequestIsGetRequest()
        {
            var seasonVideosGetRequest = new TMDBSeasonVideosGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            seasonVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBSeasonVideosGetRequestValidate()
        {
            var seasonVideosGetRequest = new TMDBSeasonVideosGetRequest
            {
                Id = 0,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr
            };

            Action act = () => seasonVideosGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
