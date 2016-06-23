namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktSearchModuleTests
    {
        [TestMethod]
        public void TestTraktSearchModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktSearchModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SearchTextQuery

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQuery()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}", searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithType()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var query = "batman";
            var type = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.AsString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYear()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var query = "batman";
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&year={year}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, year).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndYear()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var query = "batman";
            var type = TraktSearchResultType.Movie;
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.AsString()}&year={year}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type, year).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var query = "batman";
            var type = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.AsString()}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var query = "batman";
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&year={year}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, year, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var query = "batman";
            var type = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.AsString()}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var query = "batman";
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&year={year}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, year, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithTypeAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var query = "batman";
            var type = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?query={query}&type={type.AsString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryWithYearAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var query = "batman";
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?query={query}&year={year}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, null, year, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var query = "batman";
            var type = TraktSearchResultType.Movie;
            var year = 2016;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?query={query}&type={type.AsString()}&year={year}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query, type, year, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryExceptions()
        {
            var query = "batman";
            var uri = $"search?query={query}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchTextQueryArgumentExceptions()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}", searchResults);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SearchIdLookup

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookup()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.AsString()}&id={lookupId}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?id_type={type.AsString()}&id={lookupId}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?id_type={type.AsString()}&id={lookupId}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search?id_type={type.AsString()}&id={lookupId}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupExceptions()
        {
            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;
            var uri = $"search?id_type={type.AsString()}&id={lookupId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktPaginationListResult<TraktSearchIdLookupResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktSearchModuleSearchIdLookupArgumentExceptions()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var lookupId = "tt0848228";
            var type = TraktSearchLookupIdType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.AsString()}&id={lookupId}",
                                                                searchResults);

            Func<Task<TraktPaginationListResult<TraktSearchIdLookupResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(TraktSearchLookupIdType.Unspecified, lookupId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, "lookup id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
