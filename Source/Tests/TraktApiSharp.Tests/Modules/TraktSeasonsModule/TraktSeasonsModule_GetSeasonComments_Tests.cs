namespace TraktApiSharp.Tests.Modules.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_COMMENTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/comments";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, SEASON_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}",
                                                           SEASON_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?page={PAGE}",
                                                           SEASON_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}",
                                                           SEASON_COMMENTS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_COMMENTS_URI}/{COMMENT_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_COMMENTS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktComment> response = await client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR, COMMENT_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktSeasonNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonComments_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_COMMENTS_URI, SEASON_COMMENTS_JSON, 1, 10, 1, ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktComment>>> act = () => client.Seasons.GetSeasonCommentsAsync(null, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonCommentsAsync(string.Empty, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonCommentsAsync("show id", SEASON_NR);
            act.Should().Throw<ArgumentException>();
        }
    }
}
