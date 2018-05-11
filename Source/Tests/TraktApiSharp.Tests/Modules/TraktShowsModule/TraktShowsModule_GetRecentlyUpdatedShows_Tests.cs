namespace TraktApiSharp.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private const string GET_RECENTLY_UPDATED_SHOWS_URI = "shows/updates";

        [Fact]
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_RECENTLY_UPDATED_SHOWS_URI,
                RECENTLY_UPDATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync();

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?extended={EXTENDED_INFO}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?page={PAGE}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_StartDate_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_StartDate_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}?page={PAGE}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_StartDate_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}?limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(null, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_With_StartDate_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}?page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetRecentlyUpdatedShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_RECENTLY_UPDATED_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                RECENTLY_UPDATED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRecentlyUpdatedShow> response =
                await client.Shows.GetRecentlyUpdatedShowsAsync(TODAY, EXTENDED_INFO, pagedParameters);

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
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetRecentlyUpdatedShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_RECENTLY_UPDATED_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act = () => client.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
