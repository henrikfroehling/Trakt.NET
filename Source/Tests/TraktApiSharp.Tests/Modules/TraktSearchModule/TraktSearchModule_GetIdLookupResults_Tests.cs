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

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, LOOKUP_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GetIdLookupUri, SEARCH_ID_LOOKUP_RESULTS_JSON,
                                                           1, 10, 1, ID_LOOKUP_ITEM_COUNT);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act = () => client.Search.GetIdLookupResultsAsync(default(TraktSearchIdType), LOOKUP_ID);
            act.Should().Throw<ArgumentNullException>();

            act = () => client.Search.GetIdLookupResultsAsync(TraktSearchIdType.Unspecified, LOOKUP_ID);
            act.Should().Throw<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Search.GetIdLookupResultsAsync(ID_LOOKUP_TYPE, "lookup id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
