using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetRecentlyUpdatedMoviesTests
    {
        private const string GetRecentlyUpdatedMoviesUri = "movies/updates";
        private static readonly DateTime StartDate = new(2024, 9, 23, 19, 8, 15, DateTimeKind.Utc);
        private const string StartDateValue = "2024-09-23T19:00:00Z";

        [Theory]
        [InlineData(null, null, null, GetRecentlyUpdatedMoviesUri, "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetRecentlyUpdatedMoviesUri, "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedMoviesUri}?extended=full", "Movies\\updatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetRecentlyUpdatedMoviesUri}?extended=full&page=4", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetRecentlyUpdatedMoviesUri}?extended=full&limit=20", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}?extended=full&page=4&limit=20", "Movies\\updatedmovies.json")]
        public async Task TestGetRecentlyUpdatedMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktUpdatedMovie> updatedMovies = response.Content!;

            TraktUpdatedMovie updatedMovie = updatedMovies[0];

            updatedMovie.Title.ShouldBe("Second Life");
            updatedMovie.Year.ShouldBe(2024U);
            updatedMovie.IDs!.Slug.ShouldBe("second-life-2024-1110139");

            updatedMovie = updatedMovies[1];

            updatedMovie.Title.ShouldBe("Milk & Serial");
            updatedMovie.Year.ShouldBe(2024U);
            updatedMovie.IDs!.Slug.ShouldBe("milk-serial-2024");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full", "Movies\\updatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&page=4", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&limit=20", "Movies\\updatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetRecentlyUpdatedMoviesUri}/{StartDateValue}?extended=full&page=4&limit=20", "Movies\\updatedmovies.json")]
        public async Task TestGetRecentlyUpdatedMoviesWithStartDate(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(extendedInfo, StartDate, page, limit);

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

            IReadOnlyList<TraktUpdatedMovie> updatedMovies = response.Content!;

            TraktUpdatedMovie updatedMovie = updatedMovies[0];

            updatedMovie.Title.ShouldBe("Second Life");
            updatedMovie.Year.ShouldBe(2024U);
            updatedMovie.IDs!.Slug.ShouldBe("second-life-2024-1110139");

            updatedMovie = updatedMovies[1];

            updatedMovie.Title.ShouldBe("Milk & Serial");
            updatedMovie.Year.ShouldBe(2024U);
            updatedMovie.IDs!.Slug.ShouldBe("milk-serial-2024");
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

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
        public async Task TestGetRecentlyUpdatedMoviesPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

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
        public async Task TestGetRecentlyUpdatedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

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
        public async Task TestGetRecentlyUpdatedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

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
        public async Task TestGetRecentlyUpdatedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetRecentlyUpdatedMoviesPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktUpdatedMovie> response = await client.Movies.GetRecentlyUpdatedMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetRecentlyUpdatedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
