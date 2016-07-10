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
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.WithoutOAuth.Search;
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
        public void TestTraktSearchModuleGetTextQueryResults()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.AsString()}?query={query}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilter()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Show;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Episode;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Person;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}" +
                $"&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.List;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}" +
                $"&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.AsString()}?query={query}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.AsString()}?query={query}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.AsString()}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}" +
                $"&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, filter,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsExceptions()
        {
            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var uri = $"search/{type.AsString()}?query={query}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktSearchModuleGetTextQueryResultsArgumentExceptions()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.AsString()}?query={query}", searchResults);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(TraktSearchResultType.Unspecified, query);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region Old

        #region SearchOldTextQuery

        [TestMethod]
        public void TestTraktSearchModuleSearchOldTextQuery()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithType()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithYear()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithTypeAndYear()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithPage()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithTypeAndPage()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithYearAndPage()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithTypeAndLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithYearAndLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithPageAndLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithTypeAndPageAndLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryWithYearAndPageAndLimit()
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
        public void TestTraktSearchModuleSearchOldTextQueryComplete()
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
        public void TestTraktSearchModuleSearchOldTextQueryExceptions()
        {
            var query = "batman";
            var uri = $"search?query={query}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(query);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktSearchModuleSearchOldTextQueryArgumentExceptions()
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
            var type = TraktSearchIdLookupType.ImDB;

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
            var type = TraktSearchIdLookupType.ImDB;

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
            var type = TraktSearchIdLookupType.ImDB;

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
            var type = TraktSearchIdLookupType.ImDB;

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
            var type = TraktSearchIdLookupType.ImDB;
            var uri = $"search?id_type={type.AsString()}&id={lookupId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, lookupId);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.AsString()}&id={lookupId}",
                                                                searchResults);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(TraktSearchIdLookupType.Unspecified, lookupId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(type, "lookup id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        #endregion
    }
}
