using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetRecentlyUpdatedMovieTraktIDsTests
    {
        private const string GetRecentlyUpdatedMovieTraktIDsUri = "movies/updates/id";
        private static readonly DateTime StartDate = new(2024, 9, 24, 21, 24, 15, DateTimeKind.Utc);
        private const string StartDateValue = "2024-09-24T21:00:00Z";

        [Theory]
        [InlineData(null, null, GetRecentlyUpdatedMovieTraktIDsUri, "Movies\\updatedmovieids.json")]
        [InlineData(4U, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=4", "Movies\\updatedmovieids.json")]
        [InlineData(null, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}?limit=20", "Movies\\updatedmovieids.json")]
        [InlineData(4U, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=4&limit=20", "Movies\\updatedmovieids.json")]
        public async Task TestGetRecentlyUpdatedMovieTraktIDs(uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(null, page, limit);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(10U);

            IReadOnlyList<uint> updatedMovies = response.Content!;

            updatedMovies.Count.ShouldBe(10);

            updatedMovies[0].ShouldBe(366829U);
            updatedMovies[1].ShouldBe(1110521U);
            updatedMovies[2].ShouldBe(1110522U);
            updatedMovies[3].ShouldBe(1110523U);
            updatedMovies[4].ShouldBe(361391U);
            updatedMovies[5].ShouldBe(823915U);
            updatedMovies[6].ShouldBe(766592U);
            updatedMovies[7].ShouldBe(556530U);
            updatedMovies[8].ShouldBe(855458U);
            updatedMovies[9].ShouldBe(1108919U);
        }

        [Theory]
        [InlineData(null, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}", "Movies\\updatedmovieids.json")]
        [InlineData(4U, null, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?page=4", "Movies\\updatedmovieids.json")]
        [InlineData(null, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?limit=20", "Movies\\updatedmovieids.json")]
        [InlineData(4U, 20U, $"{GetRecentlyUpdatedMovieTraktIDsUri}/{StartDateValue}?page=4&limit=20", "Movies\\updatedmovieids.json")]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsWithStartDate(uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(StartDate, page, limit);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(page ?? 1U);
            response.Limit.ShouldBe(limit ?? 10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(10U);

            IReadOnlyList<uint> updatedMovies = response.Content!;

            updatedMovies.Count.ShouldBe(10);

            updatedMovies[0].ShouldBe(366829U);
            updatedMovies[1].ShouldBe(1110521U);
            updatedMovies[2].ShouldBe(1110522U);
            updatedMovies[3].ShouldBe(1110523U);
            updatedMovies[4].ShouldBe(361391U);
            updatedMovies[5].ShouldBe(823915U);
            updatedMovies[6].ShouldBe(766592U);
            updatedMovies[7].ShouldBe(556530U);
            updatedMovies[8].ShouldBe(855458U);
            updatedMovies[9].ShouldBe(1108919U);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 3, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(3U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 1, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(1U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(false);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 2);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(true);
            response.HasNextPage.ShouldBe(false);

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            response = await response.GetPreviousPageAsync();

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);
        }

        [Fact]
        public async Task TestGetRecentlyUpdatedMovieTraktIDsPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\updatedmovieids.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetRecentlyUpdatedMovieTraktIDsUri}?page=1", responseContent, 1, 2, 10, 10);

            TraktPagedResponse<uint> response = await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync(page: 1);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(1U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
            response.HasPreviousPage.ShouldBe(false);
            response.HasNextPage.ShouldBe(true);

            ModuleTestUtility.SetClient(client, $"{GetRecentlyUpdatedMovieTraktIDsUri}?page=2", responseContent, 2, 2, 10, 10);

            response = await response.GetNextPageAsync();

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBe(true);
            response.HasValue.ShouldBe(true);
            response.Content.ShouldNotBeNull();
            response.Headers.ShouldNotBeNull();
            response.TraktHeaders.ShouldNotBeNull();
            response.ContentHeaders.ShouldNotBeNull();
            response.Count.ShouldBe(10);
            response.Page.ShouldBe(2U);
            response.Limit.ShouldBe(10U);
            response.PageCount.ShouldBe(2U);
            response.ItemCount.ShouldBe(10U);
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
        public async Task TestGetRecentlyUpdatedMovieTraktIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetRecentlyUpdatedMovieTraktIDsUri, statusCode);

            try
            {
                await client.Movies.GetRecentlyUpdatedMovieTraktIDsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
