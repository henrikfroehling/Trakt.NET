namespace TraktNet.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private const string GET_TRENDING_SHOWS_URI = "shows/trending";

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_TRENDING_SHOWS_URI,
                TRENDING_SHOWS_JSON, 1, 10, 1, ITEM_COUNT, USER_COUNT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?{FILTER}",
                TRENDING_SHOWS_JSON, 1, 10, 1, ITEM_COUNT, USER_COUNT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}",
                TRENDING_SHOWS_JSON, 1, 10, 1, ITEM_COUNT, USER_COUNT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}",
                TRENDING_SHOWS_JSON, 1, 10, 1, ITEM_COUNT, USER_COUNT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?page={PAGE}",
                TRENDING_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?{FILTER}&page={PAGE}",
                TRENDING_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                TRENDING_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo_And_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&{FILTER}",
                TRENDING_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?limit={LIMIT}",
                TRENDING_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?limit={LIMIT}&{FILTER}",
                TRENDING_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                TRENDING_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_ExtendedInfo_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}&limit={LIMIT}",
                TRENDING_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?page={PAGE}&limit={LIMIT}",
                TRENDING_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_With_Page_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?page={PAGE}&limit={LIMIT}&{FILTER}",
                TRENDING_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(null, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                TRENDING_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetTrendingShows_Complete_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_TRENDING_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}&{FILTER}",
                TRENDING_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT, USER_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktTrendingShow> response =
                await client.Shows.GetTrendingShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(USER_COUNT);
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetTrendingShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_TRENDING_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act = () => client.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
