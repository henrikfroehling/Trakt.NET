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
        private const string GET_MOST_COLLECTED_SHOWS_URI = "shows/collected";

        [Fact]
        public async Task Test_TraktShowsModule_GetMostCollectedShows()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_MOST_COLLECTED_SHOWS_URI,
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync();

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, FILTER);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, FILTER);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?page={PAGE}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?page={PAGE}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?limit={LIMIT}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?extended={EXTENDED_INFO}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, EXTENDED_INFO);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?extended={EXTENDED_INFO}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, 10, 1, ITEM_COUNT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?page={PAGE}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?page={PAGE}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?{FILTER}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Page_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}&page={PAGE}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, 10, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, 1, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?page={PAGE}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Page_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?page={PAGE}&limit={LIMIT}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_ExtendedInfo_And_Page_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}?extended={EXTENDED_INFO}&page={PAGE}&{FILTER}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(null, EXTENDED_INFO, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?page={PAGE}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_With_Period_And_Page_And_Limit_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?page={PAGE}&limit={LIMIT}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, null, FILTER, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, EXTENDED_INFO, null, pagedParameters);

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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_Complete_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_MOST_COLLECTED_SHOWS_URI}/{TIME_PERIOD.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}&{FILTER}",
                MOST_COLLECTED_SHOWS_JSON, PAGE, LIMIT, 1, ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktMostPWCShow> response =
                await client.Shows.GetMostCollectedShowsAsync(TIME_PERIOD, EXTENDED_INFO, FILTER, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
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
        public async Task Test_TraktShowsModule_GetMostCollectedShows_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOST_COLLECTED_SHOWS_URI, statusCode);

            try
            {
                await client.Shows.GetMostCollectedShowsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
