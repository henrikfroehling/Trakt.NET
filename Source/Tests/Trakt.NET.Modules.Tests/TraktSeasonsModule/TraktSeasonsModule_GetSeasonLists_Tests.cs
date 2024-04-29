namespace TraktNet.Modules.Tests.TraktSeasonsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_LISTS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/lists";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI, SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/lists",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(TRAKT_SHOD_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/lists",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(showIds, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons/{SEASON_NR}/lists",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(showIds, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/lists",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(showIds, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Show()
        {
            var show = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = TRAKT_SHOD_ID,
                    Slug = SHOW_SLUG
                }
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/lists",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(show, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI,
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?extended={EXTENDED_INFO}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?extended={EXTENDED_INFO}",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_And_ExtendedInfo_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?extended={EXTENDED_INFO}",
                                                           SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_And_Page_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_And_Limit_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_SortOrder_Page_And_Limit_And_Without_Type()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}?page={PAGE}&limit={LIMIT}",
                                                           SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?extended={EXTENDED_INFO}",
                SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}",
                                                           SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?limit={LIMIT}",
                                                           SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page={PAGE}&limit={LIMIT}",
                SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}",
                SEASON_LISTS_JSON, PAGE, 10, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_With_Type_And_SortOrder_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEASON_LISTS_JSON, PAGE, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);
            var response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_LISTS_JSON, 2, LIMIT, 5, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_LISTS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 1, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_LISTS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetMockClient(client, $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=1&limit={LIMIT}",
                SEASON_LISTS_JSON, 1, LIMIT, 2, LIST_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);
            TraktPagedResponse<ITraktList> response = await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR, LIST_TYPE, LIST_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetMockClient(client, $"{GET_SEASON_LISTS_URI}/{LIST_TYPE.UriName}/{LIST_SORT_ORDER.UriName}?page=2&limit={LIMIT}",
                SEASON_LISTS_JSON, 2, LIMIT, 2, LIST_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(LIST_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(LIST_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktSeasonNotFoundException))]
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
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI, statusCode);

            try
            {
                await client.Seasons.GetSeasonListsAsync(SHOW_ID, SEASON_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonLists_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_LISTS_URI, SEASON_LISTS_JSON, 1, 10, 1, LIST_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktList>>> act = () => client.Seasons.GetSeasonListsAsync(default(ITraktShowIds), SEASON_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonListsAsync(default(ITraktShow), SEASON_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Seasons.GetSeasonListsAsync(new TraktShowIds(), SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Seasons.GetSeasonListsAsync(0, SEASON_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
