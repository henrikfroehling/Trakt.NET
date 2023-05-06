namespace TraktNet.Modules.Tests.TraktSyncModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Sync")]
    public partial class TraktSyncModule_Tests
    {
        private readonly string GET_PERSONAL_RECOMMENDATIONS_URI = $"sync/recommendations";

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                GET_PERSONAL_RECOMMENDATIONS_URI,
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response = await client.Sync.GetPersonalRecommendationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}",
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}",
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?extended={EXTENDED_INFO}",
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?page={PAGE}",
                RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_SortOrder_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}",
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?page={PAGE}",
                RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_RecommendationType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}",
                RECOMMENDATIONS_JSON, 1, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_Page()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?page={PAGE}",
                RECOMMENDATIONS_JSON, PAGE, 10, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}?page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page={PAGE}&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, PAGE, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_HasPreviousPage_And_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 2, RECOMMENDATIONS_LIMIT, 5, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(5);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_Only_HasPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 2, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_Only_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_Not_HasPreviousPage_Or_HasNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 1, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_GetPreviousPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 2, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(2, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(2);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeTrue();
            response.HasNextPage.Should().BeFalse();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            response = await response.GetPreviousPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Paging_GetNextPage()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=1&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 1, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(1, RECOMMENDATIONS_LIMIT);

            TraktPagedResponse<ITraktRecommendation> response =
                await client.Sync.GetPersonalRecommendationsAsync(RECOMMENDATION_TYPE, RECOMMENDATION_SORT_ORDER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
            response.Page.Should().Be(1);
            response.PageCount.Should().HaveValue().And.Be(2);
            response.HasPreviousPage.Should().BeFalse();
            response.HasNextPage.Should().BeTrue();

            TestUtility.ResetOAuthMockClient(client,
                $"{GET_PERSONAL_RECOMMENDATIONS_URI}/{RECOMMENDATION_TYPE.UriName}/{RECOMMENDATION_SORT_ORDER.UriName}" +
                $"?extended={EXTENDED_INFO}&page=2&limit={RECOMMENDATIONS_LIMIT}",
                RECOMMENDATIONS_JSON, 2, RECOMMENDATIONS_LIMIT, 2, RECOMMENDATIONS_ITEM_COUNT);

            response = await response.GetNextPageAsync();
            
            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(RECOMMENDATIONS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(RECOMMENDATIONS_ITEM_COUNT);
            response.Limit.Should().Be(RECOMMENDATIONS_LIMIT);
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
        public async Task Test_TraktSyncModule_GetPersonalRecommendations_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_PERSONAL_RECOMMENDATIONS_URI, statusCode);

            try
            {
                await client.Sync.GetPersonalRecommendationsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
