#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBEpisodeVideosGetRequestTests
    {
        private const string URIPath = $"shows/{TMDBTestConstants.Shows.ShowIDString}/season/{TMDBTestConstants.Episodes.EpisodeNrString}/episode/{TMDBTestConstants.Episodes.EpisodeNrString}/videos";

        [Fact]
        public void TestTMDBEpisodeVideosGetRequestHasValidURIPath()
        {
            var episodeVideosGetRequest = new TMDBEpisodeVideosGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            episodeVideosGetRequest.BuildUri();
            episodeVideosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBEpisodeVideosGetRequestIsGetRequest()
        {
            var episodeVideosGetRequest = new TMDBEpisodeVideosGetRequest
            {
                Id = TMDBTestConstants.Shows.ShowID,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            episodeVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBEpisodeVideosGetRequestValidate()
        {
            var episodeVideosGetRequest = new TMDBEpisodeVideosGetRequest
            {
                Id = 0,
                SeasonNumber = TMDBTestConstants.Seasons.SeasonNr,
                EpisodeNumber = TMDBTestConstants.Episodes.EpisodeNr
            };

            Action act = () => episodeVideosGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
