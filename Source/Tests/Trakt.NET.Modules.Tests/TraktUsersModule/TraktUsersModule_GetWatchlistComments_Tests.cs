namespace TraktNet.Modules.Tests.TraktUsersModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Users")]
    public partial class TraktUsersModule_Tests
    {
        private readonly string GET_WATCHLIST_COMMENTS_URI = $"users/{USERNAME}/watchlist/comments";

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_WATCHLIST_COMMENTS_URI,
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetWatchlistCommentsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_OAuth_Enforced()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_WATCHLIST_COMMENTS_URI,
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            client.Configuration.ForceAuthorization = true;

            TraktPagedResponse<ITraktComment> response = await client.Users.GetWatchlistCommentsAsync(USERNAME);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_OAuth_Enforced_For_Username_Me()
        {
            TraktClient client = TestUtility.GetOAuthMockClient("users/me/watchlist/comments",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Users.GetWatchlistCommentsAsync("me");

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Sort()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Sort_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Sort_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_WATCHLIST_COMMENTS_URI}?page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_WATCHLIST_COMMENTS_URI}?limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(null, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_WATCHLIST_COMMENTS_URI}?page={PAGE}&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, PAGE, COMMENTS_LIMIT, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 2, COMMENTS_LIMIT, 5, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 2, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, COMMENTS_LIMIT, 1, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 2, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(2, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client,
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            response = await response.GetPreviousPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=1&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 1, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            var pagedParameters = new TraktPagedParameters(1, COMMENTS_LIMIT);

            TraktPagedResponse<ITraktComment> response =
                await client.Users.GetWatchlistCommentsAsync(USERNAME, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client,
                $"{GET_WATCHLIST_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page=2&limit={COMMENTS_LIMIT}",
                COMMENTS_JSON, 2, COMMENTS_LIMIT, 2, COMMENTS_COUNT);

            response = await response.GetNextPageAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_COUNT);
            response.Limit.Should().Be(COMMENTS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktUsersModule_GetWatchlistComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_WATCHLIST_COMMENTS_URI, statusCode);

            try
            {
                await client.Users.GetWatchlistCommentsAsync(USERNAME);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
