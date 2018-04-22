namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_LISTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/lists";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, EPISODE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}",
                                                           EPISODE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, LIST_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_SortOrder_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI,
                                                           EPISODE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 null, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}?page={PAGE}",
                                                           EPISODE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}?limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}",
                                                           EPISODE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 LIST_TYPE, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}",
                                                           EPISODE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}?limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR,
                                                                                                 LIST_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}",
                                                           EPISODE_LISTS_JSON, PAGE, 10, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, LIST_TYPE,
                                                                                                 LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_With_Type_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, 1, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, LIST_TYPE,
                                                                                                 LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_EPISODE_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                                                           EPISODE_LISTS_JSON, PAGE, LIMIT, 1, LISTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR, LIST_TYPE,
                                                                                                 LIST_SORT_ORDER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LISTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LISTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeLists_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_LISTS_URI, EPISODE_LISTS_JSON, 1, 10, 1, LISTS_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Episodes.GetEpisodeListsAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeListsAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeListsAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeListsAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
