using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetPopularMoviesTests
    {
        private const string GetPopularMoviesUri = "movies/popular";

        [Theory]
        [InlineData(null, null, null, GetPopularMoviesUri, "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetPopularMoviesUri, "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetPopularMoviesUri}?extended=full", "Movies\\movies.json")]
        [InlineData(null, 4U, null, $"{GetPopularMoviesUri}?page=4", "Movies\\movies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetPopularMoviesUri}?limit=20", "Movies\\movies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetPopularMoviesUri}?page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetPopularMoviesUri}?page=4", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetPopularMoviesUri}?limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetPopularMoviesUri}?page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetPopularMoviesUri}?extended=full&page=4", "Movies\\movies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetPopularMoviesUri}?extended=full&limit=20", "Movies\\movies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetPopularMoviesUri}?extended=full&page=4&limit=20", "Movies\\movies.json")]
        public async Task TestGetPopularMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(extendedInfo, null, page, limit);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktMovie> popularMovies = response.Content!;

            TraktMovie popularMovie = popularMovies[0];

            popularMovie.Title.ShouldBe("Deadpool");
            popularMovie.Year.ShouldBe(2016U);
            popularMovie.IDs!.Slug.ShouldBe("deadpool-2016");

            popularMovie = popularMovies[1];

            popularMovie.Title.ShouldBe("Guardians of the Galaxy");
            popularMovie.Year.ShouldBe(2014U);
            popularMovie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\movies.json")]
        [InlineData(null, 4U, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\movies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\movies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\movies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\movies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetPopularMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\movies.json")]
        public async Task TestGetPopularMoviesWithFilter(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(extendedInfo, TestConstants.Movies.Filter, page, limit);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);

            IReadOnlyList<TraktMovie> popularMovies = response.Content!;

            TraktMovie popularMovie = popularMovies[0];

            popularMovie.Title.ShouldBe("Deadpool");
            popularMovie.Year.ShouldBe(2016U);
            popularMovie.IDs!.Slug.ShouldBe("deadpool-2016");

            popularMovie = popularMovies[1];

            popularMovie.Title.ShouldBe("Guardians of the Galaxy");
            popularMovie.Year.ShouldBe(2014U);
            popularMovie.IDs!.Slug.ShouldBe("guardians-of-the-galaxy-2014");
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);

            ModuleTestUtility.SetClient(client, $"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            response = await response.GetPreviousPageAsync();

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetPopularMoviesPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetPopularMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetPopularMoviesAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetPopularMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            response = await response.GetNextPageAsync();

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(2);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(2U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
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
        public async Task TestGetPopularMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetPopularMoviesUri, statusCode);

            try
            {
                await client.Movies.GetPopularMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
