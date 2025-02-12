using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetBoxOfficeMoviesTests
    {
        private const string GetBoxOfficeMoviesUri = "movies/boxoffice";

        [Theory]
        [InlineData(null, GetBoxOfficeMoviesUri, "Movies\\boxofficemovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, GetBoxOfficeMoviesUri, "Movies\\boxofficemovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, $"{GetBoxOfficeMoviesUri}?extended=full", "Movies\\boxofficemovies.json")]
        public async Task TestGetBoxOfficeMovies(TraktExtendedInfo? extendedInfo, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent);

            TraktListResponse<TraktBoxOfficeMovie> response = await client.Movies.GetBoxOfficeMoviesAsync(extendedInfo);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);

            IReadOnlyList<TraktBoxOfficeMovie> boxOfficeMovies = response.Content!;

            TraktBoxOfficeMovie boxOfficeMovie = boxOfficeMovies[0];

            boxOfficeMovie.Title.ShouldBe("Beetlejuice Beetlejuice");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs!.Slug.ShouldBe("beetlejuice-beetlejuice-2024");

            boxOfficeMovie = boxOfficeMovies[1];

            boxOfficeMovie.Title.ShouldBe("Speak No Evil");
            boxOfficeMovie.Year.ShouldBe(2024U);
            boxOfficeMovie.IDs!.Slug.ShouldBe("speak-no-evil-2024");
        }

        [Theory]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktApiBadRequestException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktApiAuthorizationException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktApiForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktApiMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktApiConflictException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktApiPreconditionFailedException))]
        [InlineData((HttpStatusCode)420, typeof(TraktApiAccountLimitException))]
#if TRAKT_NET_4XX_FRAMEWORK_TARGET
        [InlineData((HttpStatusCode)422, typeof(TraktApiValidationException))]
        [InlineData((HttpStatusCode)423, typeof(TraktApiLockedUserAccountException))]
        [InlineData((HttpStatusCode)429, typeof(TraktApiRateLimitException))]
#else
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktApiValidationException))]
        [InlineData(HttpStatusCode.Locked, typeof(TraktApiLockedUserAccountException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktApiRateLimitException))]
#endif
        [InlineData(HttpStatusCode.UpgradeRequired, typeof(TraktApiVIPValidationException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktApiServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktApiBadGatewayException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktApiServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktApiGatewayTimeoutException))]
        [InlineData((HttpStatusCode)520, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)521, typeof(TraktApiCloudflareException))]
        [InlineData((HttpStatusCode)522, typeof(TraktApiCloudflareException))]
        public async Task TestGetBoxOfficeMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetBoxOfficeMoviesUri, statusCode);

            try
            {
                await client.Movies.GetBoxOfficeMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
