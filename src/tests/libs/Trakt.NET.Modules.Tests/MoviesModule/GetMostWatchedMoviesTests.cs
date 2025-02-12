using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMostWatchedMoviesTests
    {
        private const string GetMostWatchedMoviesUri = "movies/watched";

        [Theory]
        [InlineData(null, null, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostWatchedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostWatchedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostWatchedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostWatchedMoviesUri}/monthly", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, GetMostWatchedMoviesUri, "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostWatchedMoviesUri}/monthly", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}/monthly?extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostWatchedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostWatchedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostWatchedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostWatchedMovies(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, null, page, limit);

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

            IReadOnlyList<TraktMostWatchedMovie> watchedMovies = response.Content!;

            TraktMostWatchedMovie watchedMovie = watchedMovies[0];

            watchedMovie.Title.ShouldBe("The Hunt for Red October");
            watchedMovie.Year.ShouldBe(1990U);
            watchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");

            watchedMovie = watchedMovies[1];

            watchedMovie.Title.ShouldBe("Rebel Ridge");
            watchedMovie.Year.ShouldBe(2024U);
            watchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(null, null, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, null, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, null, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&page=4", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.None, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&page=4&limit=20", "Movies\\mostpwcmovies_minimal.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, null, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, null, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        [InlineData(TraktTimePeriod.Monthly, TraktExtendedInfo.Full, 4U, 20U, $"{GetMostWatchedMoviesUri}/monthly?genres=action,drama&years=2024&extended=full&page=4&limit=20", "Movies\\mostpwcmovies.json")]
        public async Task TestGetMostWatchedMoviesWithFilter(TraktTimePeriod? period, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, TestConstants.Movies.Filter, page, limit);

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

            IReadOnlyList<TraktMostWatchedMovie> watchedMovies = response.Content!;

            TraktMostWatchedMovie watchedMovie = watchedMovies[0];

            watchedMovie.Title.ShouldBe("The Hunt for Red October");
            watchedMovie.Year.ShouldBe(1990U);
            watchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");

            watchedMovie = watchedMovies[1];

            watchedMovie.Title.ShouldBe("Rebel Ridge");
            watchedMovie.Year.ShouldBe(2024U);
            watchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
        }

        [Fact]
        public async Task TestGetMostWatchedMoviesPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2);

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
        public async Task TestGetMostWatchedMoviesPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1);

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
        public async Task TestGetMostWatchedMoviesPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2);

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
        public async Task TestGetMostWatchedMoviesPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1);

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
        public async Task TestGetMostWatchedMoviesPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMostWatchedMoviesPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\mostpwcmovies_minimal.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMostWatchedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMostWatchedMovie> response = await client.Movies.GetMostWatchedMoviesAsync(page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMostWatchedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMostWatchedMoviesThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMostWatchedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetMostWatchedMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }
    }
}
