using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieListsTests
    {
        private const string GetMovieListsUriPrefix = "movies";
        private const string GetMovieListsUriSuffix = "lists";
        private const string GetMovieListsUriWithSlug = GetMovieListsUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieListsUriSuffix;
        private static readonly string GetMovieListsUri = $"{GetMovieListsUriPrefix}/{TestConstants.Movies.MovieID}/{GetMovieListsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriPrefix}/293990/{GetMovieListsUriSuffix}/official/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithID(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, listType, listSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriWithSlug}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriWithSlug}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriWithSlug}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriWithSlug}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithSlug(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, listType, listSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Theory]
        [InlineData(null, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(null, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriWithSlug}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, null, $"{GetMovieListsUriWithSlug}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieListsUriWithSlug, "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, null, $"{GetMovieListsUriWithSlug}/official/updated", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, null, $"{GetMovieListsUriWithSlug}/official/updated?extended=full", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriWithSlug}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriWithSlug}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, null, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, null, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&page=4", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, null, 20U, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Unspecified, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        [InlineData(TraktListType.Official, TraktListSortOrder.Updated, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieListsUriWithSlug}/official/updated?extended=full&page=4&limit=20", "Movies\\movielists.json")]
        public async Task TestGetMovieListsWithIDs(TraktListType? listType, TraktListSortOrder? listSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, listType, listSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktList> movieLists = response.Content!;

            TraktList movieList = movieLists[0];

            movieList.Name.ShouldBe("MARVEL Cinematic Universe");
            movieList.Description.ShouldBe("MCU Shows and Movies in chronological order.");

            movieList = movieLists[1];

            movieList.Name.ShouldBe("Top Watched Movies of The Week / >60");
            movieList.Description.ShouldBe("This list is maintained by mdblist.com");
        }

        [Fact]
        public async Task TestGetMovieListsWithIDPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieListsWithIDPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieListsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieListsWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieListsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieListsWithIDPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieListsWithSlugPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieListsWithSlugPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieListsWithSlugPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieListsWithSlugPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieListsWithSlugPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieListsWithSlugPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieListsWithIDsPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieListsWithIDsPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieListsWithIDsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieListsWithIDsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieListsWithIDsPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieListsWithIDsPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieListsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktList> response = await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieListsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieListsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUri, statusCode);

            try
            {
                await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieID);
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
        public async Task TestGetMovieListsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieSlug);
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
        public async Task TestGetMovieListsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieListsAsync(TestConstants.Movies.MovieIDs);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetMovieListsWithIDsThrowsArgumentException()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\movielists.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieListsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktList>>> act = () => client.Movies.GetMovieListsAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieListsAsync(movieIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
