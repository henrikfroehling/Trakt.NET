namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private const string GET_POPULAR_SHOWS_URI = "shows/popular";

        [Fact]
        public async Task Test_TraktShowsModule_GetPopularShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_POPULAR_SHOWS_URI,
                POPULAR_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync();

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
        public async Task Test_TraktShowsModule_GetPopularShows_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?{FILTER}",
                POPULAR_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, FILTER);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}",
                POPULAR_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}",
                POPULAR_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?page={PAGE}",
                POPULAR_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?{FILTER}&page={PAGE}",
                POPULAR_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                POPULAR_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo_And_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&{FILTER}",
                POPULAR_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?limit={LIMIT}",
                POPULAR_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?limit={LIMIT}&{FILTER}",
                POPULAR_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                POPULAR_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_ExtendedInfo_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}&limit={LIMIT}",
                POPULAR_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?page={PAGE}&limit={LIMIT}",
                POPULAR_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_With_Page_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?page={PAGE}&limit={LIMIT}&{FILTER}",
                POPULAR_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                POPULAR_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetPopularShows_Complete_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_POPULAR_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}&{FILTER}",
                POPULAR_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetPopularShowsAsync(EXTENDED_INFO, FILTER, pagedParameters);

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
        public void Test_TraktShowsModule_GetPopularShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetPopularShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_POPULAR_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
