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
    using TraktApiSharp.Requests.Params;
    using Utils;

    [TestClass]
    public class TraktSearchModuleTests
    {
        private const string ENCODED_COMMA = "%2C";

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}",
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
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypes()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields).Result;

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter.ToString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilter()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter.ToString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Show;
            var query = "batman";
            var field = TraktSearchField.Tagline;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Tagline;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Show;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter).Result;

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
                $"search/{type.UriName}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

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
                $"search/{typesEncoded}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Episode;
            var query = "batman";
            var field = TraktSearchField.Overview;

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
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Overview;

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
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Episode;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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
                $"search/{type.UriName}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

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
                $"search/{typesEncoded}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Person;
            var query = "batman";
            var field = TraktSearchField.Translations;

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
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Translations;

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
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndPageAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Person;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndPageAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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
                $"search/{type.UriName}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

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
                $"search/{typesEncoded}?query={query}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.List;
            var query = "batman";
            var field = TraktSearchField.Aliases;

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
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Aliases;

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
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndExtendedOptionAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.List;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndExtendedOptionAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter.ToString()}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter.ToString()}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.People;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.People;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPageAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPageAndMutlipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&{filter.ToString()}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&{filter.ToString()}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Biography;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Biography;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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
                $"search/{type.UriName}?query={query}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Name;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Name;

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithFilterAndPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithFilterAndPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var filter = new TraktSearchFilter()
                .WithYears(2011)
                .WithGenres("action", "thriller")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(70, 140)
                .WithRatings(70, 95);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&extended={extendedOption.ToString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&extended={extendedOption.ToString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Description;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Description;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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
                $"search/{type.UriName}?query={query}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPageAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPageAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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
                $"search/{type.UriName}?query={query}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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
                $"search/{type.UriName}?query={query}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithExtendedOptionAndPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithExtendedOptionAndPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPageAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPageAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPageAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={field.UriName}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={field.UriName}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&fields={fieldsEncoded}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}&page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, null, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{typesEncoded}?query={query}&page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, null, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={field.UriName}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPageAndLimitAndField()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsWithPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, null,
                                                                                        null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesWithPageAndLimitAndMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, null,
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
            var field = TraktSearchField.Title;

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
                $"search/{type.UriName}?query={query}&fields={field.UriName}&{filter.ToString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, field, filter,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";
            var field = TraktSearchField.Title;

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
                $"search/{typesEncoded}?query={query}&fields={field.UriName}&{filter.ToString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, field, filter,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsCompleteWithMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var type = TraktSearchResultType.Movie;
            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{type.UriName}?query={query}&fields={fieldsEncoded}&{filter.ToString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, query, fields, filter,
                                                                                        extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetTextQueryResultsMultipleTypesCompleteWithMultipleFields()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 5;
            var page = 2;
            var limit = 4;

            var movieType = TraktSearchResultType.Movie;
            var showType = TraktSearchResultType.Show;
            var types = movieType | showType;
            var typesUriNames = new string[] { movieType.UriName, showType.UriName };
            var typesEncoded = string.Join(ENCODED_COMMA, typesUriNames);

            var query = "batman";

            var titleField = TraktSearchField.Title;
            var overviewField = TraktSearchField.Overview;
            var fields = titleField | overviewField;
            var fieldsUriNames = new string[] { titleField.UriName, overviewField.UriName };
            var fieldsEncoded = string.Join(ENCODED_COMMA, fieldsUriNames);

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
                $"search/{typesEncoded}?query={query}&fields={fieldsEncoded}&{filter.ToString()}" +
                $"&extended={extendedOption.ToString()}&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(types, query, fields, filter,
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
            var uri = $"search/{type.UriName}?query={query}";

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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{type.UriName}?query={query}", searchResults);

            var searchResultType = default(TraktSearchResultType);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(searchResultType, null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(type, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetTextQueryResultsAsync(TraktSearchResultType.Unspecified, query);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SearchIdLookup

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResults()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultType()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedOption.ToString()}",
                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithExtendedOption()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?extended={extendedOption.ToString()}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithExtendedOptionAndPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?extended={extendedOption.ToString()}&page={page}",
                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithExtendedOptionAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?extended={extendedOption.ToString()}&limit={limit}",
                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithExtendedOptionAndPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?extended={extendedOption.ToString()}" +
                                                                $"&page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?page={page}",
                                                                searchResults, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?limit={limit}",
                                                                searchResults, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithPageAndLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}?page={page}&limit={limit}",
                                                                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, null,
                                                                                       null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var resultType = TraktSearchResultType.Movie;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"search/{idType.UriName}/{lookupId}?type={resultType.UriName}&extended={extendedOption.ToString()}" +
                $"&page={page}&limit={limit}",
                searchResults, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId, resultType,
                                                                                       extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsWithResultTypeUnspecified()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}",
                                                                searchResults, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId,
                                                                                       TraktSearchResultType.Unspecified).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSearchModuleGetIdLookupResultsExceptions()
        {
            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";
            var uri = $"search/{idType.UriName}/{lookupId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, lookupId);
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
        public void TestTraktSearchModuleGetIdLookupResultsArgumentExceptions()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var idType = TraktSearchIdType.ImDB;
            var lookupId = "tt0848228";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search/{idType.UriName}/{lookupId}", searchResults);

            var searchIdType = default(TraktSearchIdType);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(searchIdType, lookupId);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(TraktSearchIdType.Unspecified, lookupId);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(idType, "lookup id");
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.UriName}",
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.UriName}&year={year}",
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.UriName}&page={page}",
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.UriName}&limit={limit}",
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?query={query}&type={type.UriName}&page={page}&limit={limit}",
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
                $"search?query={query}&type={type.UriName}&year={year}&page={page}&limit={limit}",
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

        #region SearchOldIdLookup

        [TestMethod]
        public void TestTraktSearchModuleSearchOldIdLookup()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;

            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.UriName}&id={lookupId}",
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
        public void TestTraktSearchModuleSearchOldIdLookupWithPage()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;

            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.UriName}&id={lookupId}&page={page}",
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
        public void TestTraktSearchModuleSearchOldIdLookupWithLimit()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var limit = 4;

            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.UriName}&id={lookupId}&limit={limit}",
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
        public void TestTraktSearchModuleSearchOldIdLookupComplete()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var itemCount = 1;
            var page = 2;
            var limit = 4;

            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.UriName}&id={lookupId}&page={page}&limit={limit}",
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
        public void TestTraktSearchModuleSearchOldIdLookupExceptions()
        {
            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;
            var uri = $"search?id_type={type.UriName}&id={lookupId}";

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
        public void TestTraktSearchModuleSearchOldIdLookupArgumentExceptions()
        {
            var searchResults = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchIdLookupResults.json");
            searchResults.Should().NotBeNullOrEmpty();

            var lookupId = "tt0848228";
            var type = TraktSearchIdLookupType.ImDB;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"search?id_type={type.UriName}&id={lookupId}", searchResults);

            var searchIdLookupType = default(TraktSearchIdLookupType);

            Func<Task<TraktPaginationListResult<TraktSearchResult>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(searchIdLookupType, lookupId);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Search.GetIdLookupResultsAsync(TraktSearchIdLookupType.Unspecified, lookupId);
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
