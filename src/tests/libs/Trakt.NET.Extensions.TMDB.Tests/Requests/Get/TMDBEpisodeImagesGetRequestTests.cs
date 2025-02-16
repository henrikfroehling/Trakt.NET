#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBEpisodeImagesGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/season/{TMDBTestConstants.Episodes.EpisodeNrString}/episode/{TMDBTestConstants.Episodes.EpisodeNrString}/images";

        [Fact]
        public void TestTMDBEpisodeImagesGetRequestHasValidURIPath()
        {
            var episodeImagesGetRequest = new TMDBEpisodeImagesGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            episodeImagesGetRequest.BuildUri();
            episodeImagesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBEpisodeImagesGetRequestIsGetRequest()
        {
            var episodeImagesGetRequest = new TMDBEpisodeImagesGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            episodeImagesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBEpisodeImagesGetRequestValidate()
        {
            var episodeImagesGetRequest = new TMDBEpisodeImagesGetRequest
            {
                Id = 0,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            Action act = () => episodeImagesGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
