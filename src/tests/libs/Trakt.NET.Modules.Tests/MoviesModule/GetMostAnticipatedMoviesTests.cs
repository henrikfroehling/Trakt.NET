using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostAnticipatedMoviesTests
    {
        private const string GetMostAnticipatedMoviesUri = "movies/anticipated";

        [Theory]
        [InlineData(null, null, null, GetMostAnticipatedMoviesUri, "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetMostAnticipatedMoviesUri, "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMostAnticipatedMoviesUri}?extended=full", "Movies\\mostanticipatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMostAnticipatedMoviesUri}?page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetMostAnticipatedMoviesUri}?limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetMostAnticipatedMoviesUri}?page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetMostAnticipatedMoviesUri}?limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetMostAnticipatedMoviesUri}?extended=full&page=4", "Movies\\mostanticipatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetMostAnticipatedMoviesUri}?extended=full&limit=20", "Movies\\mostanticipatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostanticipatedmovies.json")]
        public async Task TestGetMostAnticipatedMovies(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktMostAnticipatedMovie> anticipatedMovies = response.Content!;

            TraktMostAnticipatedMovie anticipatedMovie = anticipatedMovies[0];

            anticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");

            anticipatedMovie = anticipatedMovies[1];

            anticipatedMovie.Title.ShouldBe("Blade");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
        }

        [Theory]
        [InlineData(null, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostanticipatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, null, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(null, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostanticipatedmovies_minimal.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostanticipatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostanticipatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMostAnticipatedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostanticipatedmovies.json")]
        public async Task TestGetMostAnticipatedMoviesWithFilter(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, TestConstants.Movies.Filter, page, limit);

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

            IReadOnlyList<TraktMostAnticipatedMovie> anticipatedMovies = response.Content!;

            TraktMostAnticipatedMovie anticipatedMovie = anticipatedMovies[0];

            anticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");

            anticipatedMovie = anticipatedMovies[1];

            anticipatedMovie.Title.ShouldBe("Blade");
            anticipatedMovie.Year.ShouldBe(2025U);
            anticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
        }

        [Fact]
        public async Task TestGetMostAnticipatedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2);

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
        public async Task TestGetMostAnticipatedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1);

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
        public async Task TestGetMostAnticipatedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostAnticipatedMoviesPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostanticipatedmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostAnticipatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostAnticipatedMovie> response = await client.Movies.GetMostAnticipatedMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMostAnticipatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostAnticipatedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostAnticipatedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetMostAnticipatedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
