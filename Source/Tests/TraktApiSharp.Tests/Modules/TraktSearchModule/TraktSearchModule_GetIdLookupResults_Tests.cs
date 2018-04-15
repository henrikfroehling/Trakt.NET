namespace TraktApiSharp.Tests.Modules.TraktSearchModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Search")]
    public partial class TraktSearchModule_ests
    {
        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResults()
        {
            const int itemCount = 1;
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultType()
        {
            const int itemCount = 1;
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndExtendedOption()
        {
            const int itemCount = 1;
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedInfo}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndExtendedOptionAndPage()
        {
            const int itemCount = 1;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedInfo}&page={page}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndExtendedOptionAndLimit()
        {
            const int itemCount = 1;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedInfo}&limit={limit}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndPage()
        {
            const int itemCount = 1;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&page={page}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndLimit()
        {
            const int itemCount = 1;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&limit={limit}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeAndPageAndLimit()
        {
            const int itemCount = 1;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&page={page}&limit={limit}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithExtendedInfo()
        {
            const int itemCount = 1;
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?extended={extendedInfo}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithExtendedInfoAndPage()
        {
            const int itemCount = 1;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?extended={extendedInfo}&page={page}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithExtendedInfoAndLimit()
        {
            const int itemCount = 1;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?extended={extendedInfo}&limit={limit}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithExtendedInfoAndPageAndLimit()
        {
            const int itemCount = 1;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?extended={extendedInfo}" +
                                                                $"&page={page}&limit={limit}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithPage()
        {
            const int itemCount = 1;
            const uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?page={page}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithLimit()
        {
            const int itemCount = 1;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?limit={limit}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithPageAndLimit()
        {
            const int itemCount = 1;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?page={page}&limit={limit}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsComplete()
        {
            const int itemCount = 1;
            const uint page = 2;
            const uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedInfo}" +
                $"&page={page}&limit={limit}",
                SEARCH_ID_LOOKUP_RESULTS_JSON, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsWithResultTypeUnspecified()
        {
            const int itemCount = 1;
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}",
                                                                SEARCH_ID_LOOKUP_RESULTS_JSON, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId,
                                                                                       TraktSearchResultType.Unspecified).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsExceptions()
        {
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";
            var uri = $"search/{idType.UriName}/{lookupId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSearchModule_GetIdLookupResultsArgumentExceptions()
        {
            var idType = TraktSearchIdType.ImDB;
            const string lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}", SEARCH_ID_LOOKUP_RESULTS_JSON);

            var searchIdType = default(TraktSearchIdType);

            Func<Task<TraktPagedResponse<ITraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(searchIdType, lookupId);
            act.Should().Throw<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(TraktSearchIdType.Unspecified, lookupId);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, "lookup id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
