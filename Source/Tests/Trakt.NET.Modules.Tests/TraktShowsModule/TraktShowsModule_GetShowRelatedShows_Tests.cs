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
        private readonly string GET_SHOW_RELATED_SHOWS_URI = $"shows/{SHOW_ID}/related";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_RELATED_SHOWS_URI,
                SHOW_RELATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}",
                SHOW_RELATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?page={PAGE}",
                SHOW_RELATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                SHOW_RELATED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, 1, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?page={PAGE}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, PAGE, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRelatedShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_RELATED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={RELATED_SHOWS_LIMIT}",
                SHOW_RELATED_SHOWS_JSON, PAGE, RELATED_SHOWS_LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RELATED_SHOWS_LIMIT);

            TraktPagedResponse<ITraktShow> response =
                await client.Shows.GetShowRelatedShowsAsync(SHOW_ID, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(RELATED_SHOWS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RELATED_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRelatedShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_SHOW_RELATED_SHOWS_URI,
                SHOW_RELATED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Shows.GetShowRelatedShowsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowRelatedShowsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowRelatedShowsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
