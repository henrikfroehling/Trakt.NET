#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

namespace TraktNET.GetRequests
{
    public sealed class TMDBMovieImagesGetRequestTests
    {
        private const string URIPath = $"movies/{TMDBTestConstants.Movies.MovieIDString}/images";

        [Fact]
        public void TestTMDBMovieImagesGetRequestHasValidURIPath()
        {
            var movieImagesGetRequest = new TMDBMovieImagesGetRequest { Id = TMDBTestConstants.Movies.MovieID };

            movieImagesGetRequest.BuildUri();
            movieImagesGetRequest.RequestUri.ShouldBe(new Uri(URIPath, UriKind.Relative));
        }

        [Fact]
        public void TestTMDBMovieImagesGetRequestIsGetRequest()
        {
            var movieImagesGetRequest = new TMDBMovieImagesGetRequest { Id = TMDBTestConstants.Movies.MovieID };
            movieImagesGetRequest.Method.ShouldBe(HttpMethod.Get);
        }

        [Fact]
        public void TestTMDBMovieImagesGetRequestValidate()
        {
            var movieImagesGetRequest = new TMDBMovieImagesGetRequest { Id = 0 };

            Action act = () => movieImagesGetRequest.Validate();
            act.ShouldThrow<TMDBRequestValidationException>();
        }
    }
}
