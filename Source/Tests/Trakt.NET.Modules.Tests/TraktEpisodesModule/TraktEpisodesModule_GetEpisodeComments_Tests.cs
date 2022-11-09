namespace TraktNet.Modules.Tests.TraktEpisodesModule
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

    [TestCategory("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_COMMENTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/comments";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_COMMENTS_URI, EPISODE_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                                                           EPISODE_COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, COMMENT_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}?page={PAGE}",
                                                           EPISODE_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                                                           EPISODE_COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}?limit={LIMIT}",
                                                           EPISODE_COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           EPISODE_COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           EPISODE_COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeCommments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           EPISODE_COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktEpisodeNotFoundException))]
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
        public async Task Test_TraktEpisodesModule_GetEpisodeComments_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_COMMENTS_URI, statusCode);

            try
            {
                await client.Episodes.GetEpisodeCommentsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
