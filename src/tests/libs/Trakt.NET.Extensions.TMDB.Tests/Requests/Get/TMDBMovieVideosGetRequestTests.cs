#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBMovieVideosGetRequestTests
    {
        private const string URIPath = $"movies/{TMDBTestConstants.Movies.MovieIDString}/videos";

        [Fact]
        public void TestTMDBMovieVideosGetRequestHasValidURIPath()
        {
            var movieVideosGetRequest = new TMDBMovieVideosGetRequest { Id = TMDBTestConstants.Movies.MovieID };

            movieVideosGetRequest.BuildUri();
            movieVideosGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBMovieVideosGetRequestIsGetRequest()
        {
            var movieVideosGetRequest = new TMDBMovieVideosGetRequest { Id = TMDBTestConstants.Movies.MovieID };
            movieVideosGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBMovieVideosGetRequestValidate()
        {
            var movieVideosGetRequest = new TMDBMovieVideosGetRequest { Id = 0 };

            Action act = () => movieVideosGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
