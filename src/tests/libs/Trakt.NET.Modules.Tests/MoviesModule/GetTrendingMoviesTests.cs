using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetTrendingMoviesTests
    {
        private const string GetTrendingMoviesUri = "movies/trending";

        [Theory]
        [InlineData(null, null, null, GetTrendingMoviesUri, "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetTrendingMoviesUri, "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetTrendingMoviesUri}?extended=full", "Movies\\trendingmovies.json")]
        [InlineData(null, 4U, null, $"{GetTrendingMoviesUri}?page=4", "Movies\\trendingmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetTrendingMoviesUri}?limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetTrendingMoviesUri}?page=4&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetTrendingMoviesUri}?page=4", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetTrendingMoviesUri}?limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetTrendingMoviesUri}?page=4&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetTrendingMoviesUri}?extended=full&page=4", "Movies\\trendingmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetTrendingMoviesUri}?extended=full&limit=20", "Movies\\trendingmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetTrendingMoviesUri}?extended=full&page=4&limit=20", "Movies\\trendingmovies.json")]
        public async Task TestGetTrendingMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktTrendingMovie> trendingMovies = response.Content!;

            TraktTrendingMovie trendingMovie = trendingMovies[0];

            trendingMovie.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie.Year.ShouldBe(2024U);
            trendingMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");

            trendingMovie = trendingMovies[1];

            trendingMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            trendingMovie.Year.ShouldBe(2024U);
            trendingMovie.IDs!.Slug.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\trendingmovies.json")]
        [InlineData(null, 4U, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\trendingmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\trendingmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\trendingmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\trendingmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetTrendingMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\trendingmovies.json")]
        public async Task TestGetTrendingMoviesWithFilter(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(extendedInfo, TestConstants.Movies.Filter, page, limit);

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

            IReadOnlyList<TraktTrendingMovie> trendingMovies = response.Content!;

            TraktTrendingMovie trendingMovie = trendingMovies[0];

            trendingMovie.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie.Year.ShouldBe(2024U);
            trendingMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");

            trendingMovie = trendingMovies[1];

            trendingMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            trendingMovie.Year.ShouldBe(2024U);
            trendingMovie.IDs!.Slug.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");
        }

        [Fact]
        public async Task TestGetTrendingMoviesPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 2);

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
        public async Task TestGetTrendingMoviesPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 1);

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
        public async Task TestGetTrendingMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 2);

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
        public async Task TestGetTrendingMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 1);

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
        public async Task TestGetTrendingMoviesPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetTrendingMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetTrendingMoviesPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\trendingmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetTrendingMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktTrendingMovie> response = await client.Movies.GetTrendingMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetTrendingMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetTrendingMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetTrendingMoviesUri, statusCode);

            try
            {
                await client.Movies.GetTrendingMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
