namespace TraktNet.Tests.Modules.TraktSearchModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Requests.Parameters;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Search")]
    public partial class TraktSearchModule_Tests
    {
        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUriMulitpleTypes,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetTextQueryUri}&{FILTER}",
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetTextQueryUriMulitpleTypes}&{FILTER}",
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_MutlipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Filter_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Filter_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null, null,
                                                             EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_ExtendedInfo_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_ExtendedInfo_And_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, 10, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TextQuerySearchFields, null, null,
                                                             pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, 1, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, null,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, null,
                                                             null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit_And_Field()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_With_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_With_Page_And_Limit_And_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY,
                                                             TEXT_QUERY_SEARCH_FIELD_TITLE, FILTER,
                                                             EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TEXT_QUERY_SEARCH_FIELD_TITLE.UriName}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TEXT_QUERY_SEARCH_FIELD_TITLE,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_Complete_With_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUri}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetTextQueryResults_MultipleTypes_Complete_With_MultipleFields()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetTextQueryUriMulitpleTypes}&fields={TextQuerySearchFieldsEncoded}&{FILTER}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_TEXT_QUERY_RESULTS_JSON, PAGE, LIMIT, 1, TEXT_QUERY_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetTextQueryResultsAsync(TextQueryTypes, TEXT_QUERY, TextQuerySearchFields,
                                                             FILTER, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(TEXT_QUERY_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(TEXT_QUERY_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, TEXT_QUERY);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetTextQueryResults_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GetTextQueryUri,
                                                           SEARCH_TEXT_QUERY_RESULTS_JSON, 1, 10, 1, TEXT_QUERY_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetTextQueryResultsAsync(default(TraktSearchResultType), null);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Search.GetTextQueryResultsAsync(TEXT_QUERY_TYPE_MOVIE, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Search.GetTextQueryResultsAsync(TraktSearchResultType.Unspecified, TEXT_QUERY);
            act.Should().Throw<ArgumentException>();
        }
    }
}
