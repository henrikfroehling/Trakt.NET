namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Ratings;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private const string GET_RATINGS_URI = "sync/ratings";

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_RATINGS_URI, RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);
            TraktPagedResponse<ITraktRatingsItem> response = await client.Sync.GetRatingsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1()
        {
            var ratingsFilter = new int[] { 1 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2()
        {
            var ratingsFilter = new int[] { 1, 2 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3()
        {
            var ratingsFilter = new int[] { 1, 2, 3 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_RatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_RatingsFilter()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            TraktClient client = TestUtility.GetOAuthMockClient(GET_RATINGS_URI, RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(null, ratingsFilter);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}?extended={EXTENDED_INFO}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}?page={PAGE}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}?limit={LIMIT}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Type_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}?extended={EXTENDED_INFO}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}?page={PAGE}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}?limit={LIMIT}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}?page={PAGE}&limit={LIMIT}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Complete()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                RATINGS_JSON, 1, 10, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_HasPreviousPage_And_HasNextPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RATINGS_JSON, 2, LIMIT, 5, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_Only_HasPreviousPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RATINGS_JSON, 2, LIMIT, 2, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_Only_HasNextPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RATINGS_JSON, 1, LIMIT, 2, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RATINGS_JSON, 1, LIMIT, 1, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_GetPreviousPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RATINGS_JSON, 2, LIMIT, 2, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RATINGS_JSON, 1, LIMIT, 2, RATINGS_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetRatings_Paging_GetNextPage()
        {
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=1&limit={LIMIT}",
                RATINGS_JSON, 1, LIMIT, 2, RATINGS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, LIMIT);

            TraktPagedResponse<ITraktRatingsItem> response =
                await client.Sync.GetRatingsAsync(RATINGS_ITEM_TYPE, ratingsFilter, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_RATINGS_URI}/{RATINGS_ITEM_TYPE.UriName}/{BuildRatingsFilterString(ratingsFilter)}?extended={EXTENDED_INFO}&page=2&limit={LIMIT}",
                RATINGS_JSON, 2, LIMIT, 2, RATINGS_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
            response.ItemCount.Should().HaveValue().And.Be(RATINGS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
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
        public async Task Test_TraktSyncModule_GetRatings_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_RATINGS_URI, statusCode);

            try
            {
                await client.Sync.GetRatingsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
