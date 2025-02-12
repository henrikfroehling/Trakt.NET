using System.Net;

namespace TraktNET.MoviesModule
{
    public sealed class GetMovieCommentsTests
    {
        private const string GetMovieCommentsUriPrefix = "movies";
        private const string GetMovieCommentsUriSuffix = "comments";
        private const string GetMovieCommentsUriWithSlug = GetMovieCommentsUriPrefix + "/" + TestConstants.Movies.MovieSlug + "/" + GetMovieCommentsUriSuffix;
        private static readonly string GetMovieCommentsUri = $"{GetMovieCommentsUriPrefix}/{TestConstants.Movies.MovieID}/{GetMovieCommentsUriSuffix}";

        [Theory]
        [InlineData(null, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithID(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriPrefix}/293990/{GetMovieCommentsUriSuffix}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithSlug(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithSlugWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDs(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Theory]
        [InlineData(null, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(null, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, null, GetMovieCommentsUriWithSlug, "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Unspecified, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, null, $"{GetMovieCommentsUriWithSlug}/likes", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, null, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.None, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?page=4&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, null, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, null, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&limit=20", "Movies\\moviecomments.json")]
        [InlineData(TraktCommentSortOrder.Likes, TraktExtendedInfo.Full, 4U, 20U, $"{GetMovieCommentsUriWithSlug}/likes?extended=full&page=4&limit=20", "Movies\\moviecomments.json")]
        public async Task TestGetMovieCommentsWithIDsWithOAuth(TraktCommentSortOrder? commentSortOrder, TraktExtendedInfo? extendedInfo, uint? page, uint? limit, string requestUri, string responseContentFile)
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync(responseContentFile);
            TraktClient client = ModuleTestUtility.GetOAuthClient(requestUri, responseContent, page, 1, limit, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, commentSortOrder, extendedInfo, page, limit);

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

            IReadOnlyList<TraktComment> movieComments = response.Content!;

            TraktComment movieComment = movieComments[0];
            movieComment.Comment.ShouldBe("Comment content 1.");

            movieComment = movieComments[1];
            movieComment.Comment.ShouldBe("Comment content 2.");
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieCommentsWithIDPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieCommentsWithIDPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 2);

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
        public async Task TestGetMovieCommentsWithIDPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 1);

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
        public async Task TestGetMovieCommentsWithIDPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithIDPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUri}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUri}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithSlugPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieCommentsWithSlugPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieCommentsWithSlugPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 2);

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
        public async Task TestGetMovieCommentsWithSlugPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 1);

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
        public async Task TestGetMovieCommentsWithSlugPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithSlugPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithIDsPagingHasPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieCommentsWithIDsPagingHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieCommentsWithIDsPagingHasPreviousPageAndHasNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 3, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 2);

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
        public async Task TestGetMovieCommentsWithIDsPagingHasNotPreviousPageAndHasNotNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 1, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 1);

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
        public async Task TestGetMovieCommentsWithIDsPagingGetPreviousPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 2);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithIDsPagingGetNextPage()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient($"{GetMovieCommentsUriWithSlug}?page=1", responseContent, 1, 2, 10, 2);

            TraktPagedResponse<TraktComment> response = await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs, page: 1);

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

            ModuleTestUtility.SetClient(client, $"{GetMovieCommentsUriWithSlug}?page=2", responseContent, 2, 2, 10, 2);

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
        public async Task TestGetMovieCommentsWithIDThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUri, statusCode);

            try
            {
                await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieID);
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
        public async Task TestGetMovieCommentsWithSlugThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieSlug);
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
        public async Task TestGetMovieCommentsWithIDsThrowsApiException(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUriWithSlug, statusCode);

            try
            {
                await client.Movies.GetMovieCommentsAsync(TestConstants.Movies.MovieIDs);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).ShouldBe(true);
            }
        }

        [Fact]
        public async Task TestGetMovieCommentsWithIDsThrowsArgumentException()
        {
            string responseContent = await TraktTestUtility.GetJsonFileContentAsync("Movies\\moviecomments.json");
            TraktClient client = ModuleTestUtility.GetClient(GetMovieCommentsUriWithSlug, responseContent);

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            Func<Task<TraktPagedResponse<TraktComment>>> act = () => client.Movies.GetMovieCommentsAsync(default(TraktMovieIDs));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            await act.ShouldThrowAsync<ArgumentException>();

            var movieIDs = new TraktMovieIDs();

            act = () => client.Movies.GetMovieCommentsAsync(movieIDs);
            await act.ShouldThrowAsync<ArgumentException>();
        }
    }
}
