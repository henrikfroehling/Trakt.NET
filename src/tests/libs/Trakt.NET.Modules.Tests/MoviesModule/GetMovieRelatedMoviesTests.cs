using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieRelatedMoviesTests
    {
        private const string GetMovieRelatedMoviesUriPrefix = "movies";
        private const string GetMovieRelatedMoviesUriSuffix = "related";
        private const string GetMovieRelatedMoviesUriWithSlug = GetMovieRelatedMoviesUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieRelatedMoviesUriSuffix;
        private static readonly string GetMovieRelatedMoviesUri = $"{GetMovieRelatedMoviesUriPrefix}/{TestConstants.Movies.MovieID}/{GetMovieRelatedMoviesUriSuffix}";

        [Theory]
        [InlineData(null, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?extended=full", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(null, null, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?extended=full&page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?extended=full&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieRelatedMoviesUriPrefix}/293990/{GetMovieRelatedMoviesUriSuffix}?extended=full&page=4&limit=20", "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithID(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, extendedInfo, page, limit);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content!;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Theory]
        [InlineData(null, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(null, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithSlug(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, extendedInfo, page, limit);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content!;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Theory]
        [InlineData(null, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, null, GetMovieRelatedMoviesUriWithSlug, "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, null, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(null, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(null, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.None, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?page=4&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, null, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&page=4", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, null, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&limit=20", "Movies\\movierelatedmovies.json")]
        [InlineData(TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieRelatedMoviesUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movierelatedmovies.json")]
        public async Task TestGetMovieRelatedMoviesWithIDs(TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, extendedInfo, page, limit);

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

            IReadOnlyList<TraktMovie> relatedMovies = response.Content!;

            TraktMovie relatedMovie = relatedMovies[0];

            relatedMovie.Title.ShouldBe("Avengers: Endgame");
            relatedMovie.Year.ShouldBe(2019U);
            relatedMovie.IDs!.Slug.ShouldBe("avengers-endgame-2019");

            relatedMovie = relatedMovies[1];

            relatedMovie.Title.ShouldBe("Thor: Ragnarok");
            relatedMovie.Year.ShouldBe(2017U);
            relatedMovie.IDs!.Slug.ShouldBe("thor-ragnarok-2017");
        }

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUri}?page=2", responseContent, 2, 2, 10, 2);

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

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithSlugPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithSlugPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithSlugPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithSlugPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithSlugPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieRelatedMoviesWithSlugPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithIDsPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDsPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithIDsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieRelatedMoviesWithIDsPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieRelatedMoviesWithIDsPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieRelatedMoviesUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktMovie> response = await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieRelatedMoviesUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMovieRelatedMoviesWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUri, statusCode);

            try
            {
                await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMovieRelatedMoviesWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieSlug);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktApiMovieNotFoundException))]
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
        public async Task TestGetMovieRelatedMoviesWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieRelatedMoviesAsync(TestConstants.Movies.MovieIDs);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetMovieRelatedMoviesWithIDsThrowsArgumentException()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movierelatedmovies.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieRelatedMoviesUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktMovie>>> act = () => client.Movies.GetMovieRelatedMoviesAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieRelatedMoviesAsync(movieIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
