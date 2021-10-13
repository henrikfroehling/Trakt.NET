namespace TraktNet.Modules.Tests.TraktSearchModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
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
        public async Task Test_TraktSearchModule_GetIdLookupResults()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri,
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response = await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&extended={EXTENDED_INFO}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&extended={EXTENDED_INFO}&page={PAGE}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, 10, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&extended={EXTENDED_INFO}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&page={PAGE}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, 10, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&page={PAGE}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?extended={EXTENDED_INFO}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            var ID_LOOKUP_TYPE = TraktSearchIdType.ImDB;

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?extended={EXTENDED_INFO}&page={PAGE}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, 10, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?extended={EXTENDED_INFO}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?page={PAGE}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, 10, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient($"{GetIdLookupUri}?page={PAGE}&limit={LIMIT}",
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GetIdLookupUri}?type={ID_LOOKUP_RESULT_TYPE.UriName}&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, PAGE, LIMIT, 1, ID_LOOKUP_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, ID_LOOKUP_RESULT_TYPE, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_With_ResultType_Unspecified()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri,
                                                           SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            TraktPagedResponse<ITraktSearchResult> response =
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID, TraktSearchResultType.Unspecified);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(ID_LOOKUP_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(ID_LOOKUP_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
        public async Task Test_TraktSearchModule_GetIdLookupResult_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, statusCode);

            try
            {
                await client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktSearchModule_GetIdLookupResults_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, SEARCH_ID_LOOKUP_RESULTS_JSON,
                                                           1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(default, LOOKUP_ID);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIdType.Unspecified, LOOKUP_ID);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, "lookup id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
